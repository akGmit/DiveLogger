using DiveLogger.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiveLogger.ViewModels
{
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
            SaveLogCommand = new Command<DiveLogModel>(SaveLog);
            diveLog = new DiveLogModel();
        }

        private void SaveLog(DiveLogModel obj)
        {
            UserModel.SetUserDiveLog(obj);
        }
    }
}
