using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using DiveLogger.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using DiveLogger.Utils;
using System.Collections;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;

namespace DiveLogger.ViewModels
{
    public class DiveSitesViewModel : BaseViewModel
    {
        #region Variables
        private int counterMapChange = 0;
        private ObservableCollection<DiveSiteModel> diveSites = new ObservableCollection<DiveSiteModel>();
        public ObservableCollection<DiveSiteModel> DiveSites
        {
            get => diveSites;
            set => SetValue(ref diveSites, value);
        }
        private DataTemplate diveSitesDataTemplate;
        private ListView sitesList = new ListView();
        public ListView SitesList
        {
            get => sitesList;
            set => SetValue(ref sitesList, value);
        }
        private Xamarin.Forms.Maps.Map mapSites;
        private StackLayout stack;
        public StackLayout Stack
        {
            get => stack;
            set
            { SetValue(ref stack, value); }
        }

        #endregion

        /// <summary>
        /// Constructor calling intialization methods, adding creating and displaying UI components.
        /// </summary>
        public DiveSitesViewModel()
        {
            stack = new StackLayout();
            InitializeMapAsync();
            InitializeListView();
        }

        /// <summary>
        /// Initialized dive sites list view. Creating data template for a list view.
        /// </summary>
        private void InitializeListView()
        {
            diveSitesDataTemplate = new DataTemplate(() =>
            {
                var templateStack = new StackLayout();

                var name = new Label();
                var location = new Label();
                var distance = new Label();

                name.SetBinding(Label.TextProperty, "Name");
                distance.SetBinding(Label.TextProperty, "Distance");

                templateStack.Children.Add(name);
                templateStack.Children.Add(distance);

                return new ViewCell { View = templateStack };
            });

            //Listview settings
            SitesList.ItemTemplate = diveSitesDataTemplate;
            SitesList.SetBinding(ListView.ItemsSourceProperty, "DiveSites");
            SitesList.Margin = new Thickness(0, 20, 0, 0);

        }

        /// <summary>
        /// Initializing map.
        /// </summary>
        /// <remarks>
        /// Map is initialized to last known location which is recieved from Coordinates class.
        /// Setting map properties, add PropertyChanging event to inform about map zooming and panning.
        /// Dive sites collection and map pins are updated.
        /// </remarks>
        private async void InitializeMapAsync()
        {
            Location loc = await Coordinates.GetLastKnownLocationAsync();

            mapSites = new Xamarin.Forms.Maps.Map(
            MapSpan.FromCenterAndRadius(
                    new Position(loc.Latitude, loc.Longitude), Distance.FromKilometers(kilometers: 100)))
            {
                HeightRequest = 300,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,
                MapType = MapType.Hybrid
            };

            mapSites.PropertyChanging += MapVisibleRegionChanging;

            DiveSites = await DiveSitesUtil.GetDiveSitesAsync(loc.Latitude, loc.Longitude, 100);
            UpdatePins();

            stack.Children.Add(mapSites);
            stack.Children.Add(SitesList);
        }

        /// <summary>
        /// Method called when map visible region is changing.
        /// Updating pins and divesites according to map center location.
        /// </summary>
        /// <remarks>
        /// Method keeps record of a counter which limits the frequency of update actions taken.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapVisibleRegionChanging(object sender, PropertyChangingEventArgs e)
        {
            counterMapChange++;
            if (counterMapChange == 10)
            {
                UpdatePins();
                UpdateDiveSitesAsync();
                counterMapChange = 0;
            }
        }

        /// <summary>
        /// Gets map center coordinates and updates dive sites.
        /// </summary>
        private async void UpdateDiveSitesAsync()
        {
            if (mapSites.VisibleRegion != null)
            {
                MapCoordinates coords = Coordinates.GetMapCoordinates(mapSites.VisibleRegion);
                DiveSites = await DiveSitesUtil.GetDiveSitesAsync(coords.Latitude, coords.Longitude, coords.Radius);
            }
        }

        /// <summary>
        /// Method updating and droping pins on map. 
        /// </summary>
        /// <remarks>
        /// Map pins list is cleared first and then populated from dive sites collection.
        /// </remarks>
        private void UpdatePins()
        {
            mapSites.Pins.Clear();
            foreach (DiveSiteModel site in diveSites)
            {
                var pin = new Pin
                {
                    Type = PinType.Generic,
                    Position = new Position(site.Latitude, site.Longitude),
                    Label = site.Name
                };
                mapSites.Pins.Add(pin);
            }
        }
    }
}
