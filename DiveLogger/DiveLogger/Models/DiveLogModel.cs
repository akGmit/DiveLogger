using DiveLogger.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
/// <summary>
/// Dive log model.
/// </summary>
namespace DiveLogger.Models
{
    public class DiveLogModel
    {

        #region Variables
        public int DiveNumber { get; set; }
        public double Visibility { get; set; }
        public double MaxDepth { get; set; }
        public TimeSpan Duration { get; set; }
        public double  WaterTemp { get; set; }
        public string DiveNotes { get; set; }
        public string Location { get; set; }

        #endregion

        public DiveLogModel(int diveNumber, double visibility, double maxDepth,
            TimeSpan duration, double waterTemp,
                string diveNotes, string location)
        {
            DiveNumber = diveNumber;
            Visibility = visibility;
            MaxDepth = maxDepth;
            Duration = duration;
            WaterTemp = waterTemp;
            DiveNotes = diveNotes;
            Location = location;
        }
    }
}
