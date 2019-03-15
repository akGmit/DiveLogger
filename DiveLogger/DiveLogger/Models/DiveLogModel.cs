using DiveLogger.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

namespace DiveLogger.Models
{
    public class DiveLogModel : BaseViewModel
    {

        #region Properties

        private string diveNumber;
        private string visibility;
        private string maxDepth;
        private string duration;
        private string waterTemp;
        private string totalDiveTime;
        private string diveNotes;
        private string location;

        public string DiveNumber
        {
            get => diveNumber;
            set { SetValue(ref diveNumber, value); }
        }
        public string Visibility
        {
            get => visibility;
            set { SetValue(ref visibility, value); }
        }
        public string MaxDepth
        {
            get => maxDepth;
            set { SetValue(ref maxDepth, value); }
        }
        public string Duration
        {
            get => duration;
            set { SetValue(ref duration, value); }
        }
        public string WaterTemp
        {
            get => waterTemp;
            set { SetValue(ref waterTemp, value); }
        }
        public string TotalDiveTime
        {
            get => totalDiveTime;
            set { SetValue(ref totalDiveTime, value); }
        }
        public string DiveNotes
        {
            get => diveNotes;
            set { SetValue(ref diveNotes, value); }
        }
        public string Location
        {
            get => location;
            set { SetValue(ref location, value); }
        }

        #endregion
        //private DiveLogModel diveLog;
        //public DiveLogModel DiveLog
        //{
        //    get => diveLog;
        //    set
        //    {
        //        SetValue(ref diveLog, value);
        //    }
        //}

        public DiveLogModel()
        {
        }

        public DiveLogModel(string diveNumber, string visibility, string maxDepth,
            string duration, string waterTemp,
                string totalDiveTime, string diveNotes, string location)
        {
            DiveNumber = diveNumber;
            Visibility = visibility;
            MaxDepth = maxDepth;
            Duration = duration;
            WaterTemp = waterTemp;
            TotalDiveTime = totalDiveTime;
            DiveNotes = diveNotes;
            Location = location;
        }
    }
}
