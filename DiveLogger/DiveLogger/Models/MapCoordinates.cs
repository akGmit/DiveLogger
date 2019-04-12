using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Class representing Map coordinates.
/// </summary>
namespace DiveLogger.Models
{
    class MapCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }

        public MapCoordinates(double latitude, double longitude, double radius)
        {
            Latitude = latitude;
            Longitude = longitude;
            Radius = radius;
        }
    }
}
