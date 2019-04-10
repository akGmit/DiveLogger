using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DiveLogger.ViewModels
{
    
    class DiveSitesViewModel : BaseViewModel
    {
        private Xamarin.Forms.Maps.Map mapSites;
        private StackLayout stack;
        public StackLayout Stack
        {
            get => stack;
            set
            { SetValue(ref stack, value); }
        }
        public DiveSitesViewModel()
        {
            InitializeMapAsync();

            //Initialize stack
            stack = new StackLayout();
            
            stack.Children.Add(mapSites);
        }

        private async void InitializeMapAsync()
        {
            Location location = new Location();
            try
            {
                location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            } 
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
