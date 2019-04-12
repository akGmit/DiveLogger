using DiveLogger.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace DiveLogger.Models
{
    public class Location
    {
        private Position position;
        public Position Position
        { get; set; }
            //{
        //    get => position;
        //    set => SetValue(ref position, value);
        //}
        public string Name { get; set; }
        public double Distance { get; set; }

        public Location(string name, double distance, Position position)
        {
            Name = name;
            Distance = distance;
            Position = position;
        }
    }
}
