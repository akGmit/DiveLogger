using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiveLogger.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogPageMaster : ContentPage
    {
        public ListView ListView;

        public LogPageMaster()
        {
            InitializeComponent();

            BindingContext = new LogPageMasterViewModel();
            ListView = lstViewLogPage;
        }

        class LogPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<LogPageMenuItem> MenuItems { get; set; }
            
            public LogPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<LogPageMenuItem>(new[]
                {
                    new LogPageMenuItem { Id = 0, Title = "Page 1" },
                    new LogPageMenuItem { Id = 1, Title = "Page 2" },
                    new LogPageMenuItem { Id = 2, Title = "Page 3" },
                    //new LogPageMenuItem { Id = 3, Title = "Page 4" },
                    //new LogPageMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}