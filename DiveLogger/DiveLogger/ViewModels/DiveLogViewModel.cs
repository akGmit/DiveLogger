using DiveLogger.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace DiveLogger.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    class DiveLogViewModel : BaseViewModel
    {
        public ICommand SaveLogCommand { get; private set; }

        private DiveLogModel diveLog;
        public DiveLogModel DiveLog
        {
            get => diveLog;
            set
            { SetValue(ref diveLog, value); }
        }

        public DiveLogViewModel()
        {
        }
    }
}
