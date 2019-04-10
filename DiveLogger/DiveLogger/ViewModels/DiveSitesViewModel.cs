using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using DiveLogger.Models;

namespace DiveLogger.ViewModels
{
    
    class DiveSitesViewModel : BaseViewModel
    {
        private List<DiveSiteModel> diveSites = new List<DiveSiteModel>();
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
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,
                MapType = MapType.Satellite
            };
        }
    }
}
