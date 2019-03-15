using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

namespace DiveLogger.ViewModels
{
    class DiveLogModel : BaseViewModel
    {

        #region Properties

        private int diveNumber;
        private float visibility;
        private float maxDepth;
        private TimeSpan duration;
        private float waterTemp;
        private TimeSpan totalDiveTime;
        private string diveNotes;
        private Location location;

        public int DiveNumber { get; set; }
        public float Visibility { get; set; }
        public float MaxDepth { get; set; }
        public TimeSpan Duration { get; set; }
        public float WaterTemp { get; set; }
        public TimeSpan TotalDiveTime { get; set; }
        public string DiveNotes { get; set; }
        public Location Location { get; set; }

        #endregion

        public DiveLogModel()
        {
        }

    }
}
