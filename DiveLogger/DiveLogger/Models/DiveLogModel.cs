using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

namespace DiveLogger.ViewModels
{
    class DiveLogModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties
        
        public int DiveNumber { get; set; }
        public float Visibility { get; set; }
        public float MaxDepth { get; set; }
        public TimeSpan Duration { get; set; }
        public float WaterTemp { get; set; }
        public TimeSpan TotalDiveTime { get; set; }
        public string DiveNotes { get; set; }
        public Location Location { get; set; }
        
        #endregion
    }
}
