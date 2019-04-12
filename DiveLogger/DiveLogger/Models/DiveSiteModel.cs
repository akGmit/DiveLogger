
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;
/// <summary>
/// Class representing Dive site record.
/// </summary>
/// <remarks>
/// Model properties has JsonProperty annotations for serilizing/deserializing to/from JSON format.
/// </remarks>
namespace DiveLogger.Models
{
    public class DiveSiteModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("distance")]
        public double Distance {get; set;}
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lng")]
        public double Longitude { get; set; }
        //public int Id { get; set; }

        [JsonConstructor]
        public DiveSiteModel(string name, double distance, double latitude, double longitude)
        {
            Name = name;
            Distance = distance;
            Latitude = latitude;
            Longitude = longitude;
            //Id = id;
        }
    }
}
