using DiveLogger.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
/// <summary>
/// Coordinates utilities class.
/// Responsible for providing device location and map coordinates.
/// </summary>
namespace DiveLogger.Utils
{
    class Coordinates
    {
        /// <summary>
        /// Gets last known device location.
        /// </summary>
        /// <returns>A Location type of last known device location.</returns>
        public static async Task<Location> GetLastKnownLocationAsync()
        {
            return await Geolocation.GetLastKnownLocationAsync();
        }
        /// <summary>
        /// Returns map centre coordinates accordng to visible map region.
        /// </summary>
        /// <param name="region">A MapSpan type object representing current visible region of map.</param>
        /// <returns>MapCoordintes object representing containing latitude, longitude and radius.</returns>
        public static MapCoordinates GetMapCoordinates(MapSpan region)
        {
            return new MapCoordinates(region.Center.Latitude, region.Center.Longitude, region.Radius.Kilometers);
        }
    }
}
