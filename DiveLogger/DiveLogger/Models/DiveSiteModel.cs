/***
 * Model representing Dive Site
 * 
 * ***/
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveLogger.Models
{
    class DiveSiteModel
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public DiveSiteModel(string name, string location)
        {
            Name = name;
            Location = location;
        }
    }
}
