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

namespace DiveLogger.ViewModels
{
    
    public class DiveSitesViewModel : BaseViewModel
    {
        private double lat;
        private double lng;
        private double radius;
        private bool stopTimer;
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

        //CONSTRUCTOR
        public DiveSitesViewModel()
        {
            InitializeListView();
            InitializeMapAsync();
            
            //Initialize stack
            stack = new StackLayout();
            
            //Add map to stack
            stack.Children.Add(mapSites);
            stack.Children.Add(SitesList);
        }
        
        /**
         * Method to create data template and listview which holds dive sites.
         * */
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

        /***
         * Methd to initialize map.
         * Getting current device location and centering map to it.
         * Get dive sites at current location.
         * ***/
        private async void InitializeMapAsync()
        {
            Location loc = Geolocation.GetLastKnownLocationAsync().Result;

            mapSites = new Xamarin.Forms.Maps.Map(
            MapSpan.FromCenterAndRadius(
                    new Position(loc.Latitude, loc.Longitude), Distance.FromKilometers(kilometers: 100)))
            {
                IsShowingUser = true,
                HeightRequest = 300,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,
                MapType = MapType.Satellite
            };

            DiveSites = await DiveSitesUtil.GetDiveSitesAsync(loc.Latitude, loc.Longitude, 100);
        }

        /***
         * Method to start readin map centre coordinates at specified intervals.
         * **/
        public void GetMapLatAndLong()
        {
            stopTimer = false;
            Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
                {
                    if (stopTimer)
                        return false;

                    MapSpan mapSpan = mapSites.VisibleRegion;

                    if (mapSpan != null)
                    {
                        lat = mapSpan.Center.Latitude;
                        lng = mapSpan.Center.Longitude;
                        radius = mapSpan.Radius.Kilometers;
                        Console.WriteLine(lat + " " + lng + " " + radius);
                    }
                    return true;
                });
        }
        /**
         * Start/stop timer which is responsible for running GetMapLatAndLong() method logic
         * **/
        public void StopTimer()
        {
            stopTimer = true;
        }
    }
}
