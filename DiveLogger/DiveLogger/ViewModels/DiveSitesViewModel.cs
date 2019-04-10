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

namespace DiveLogger.ViewModels
{
    
    class DiveSitesViewModel : BaseViewModel
    {
        public ObservableCollection<DiveSiteModel> diveSites = new ObservableCollection<DiveSiteModel>();
        private DataTemplate diveSitesDataTemplate = new DataTemplate(() =>
        {
            var templateStack = new StackLayout();

            var name = new Label();
            var location = new Label();

            name.SetBinding(Label.TextProperty, "Name");
            location.SetBinding(Label.TextProperty, "Location");

            templateStack.Children.Add(name);
            templateStack.Children.Add(location);

            return new ViewCell { View = templateStack };
        });
        private ListView sitesList = new ListView();
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
            InitializeMapAsync();

            //Initialize stack
            stack = new StackLayout();
            
            //Add map to stack
            stack.Children.Add(mapSites);

            diveSites.Add(new DiveSiteModel("CCCC", "CCCCVVS"));
            diveSites.Add(new DiveSiteModel("dasdfasd", "CasdfasdfCCCVVS"));

            sitesList.ItemsSource = diveSites;
            sitesList.ItemTemplate = diveSitesDataTemplate;
            sitesList.Margin = new Thickness(0, 20, 0, 0);

            stack.Children.Add(sitesList);
        }

        private async void InitializeMapAsync()
        {
            //Get current user location
            //If exception thrown, set location to default
            Location location = new Location();
            try
            {
                location = await Geolocation.GetLastKnownLocationAsync();
            }
            catch (Exception ex)
            {
                location = new Location(37, -122);
            } 

            //Initialize map to location
            mapSites = new Xamarin.Forms.Maps.Map(
            MapSpan.FromCenterAndRadius(
                    new Position(location.Latitude, location.Longitude), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 300,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,
                MapType = MapType.Satellite
            };
        }
    }
}
