using DiveLogger.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiveLogger.ViewModels
{
    class RootPageViewModel : BaseViewModel
    {
        public ICommand DiveLogPage { get; set; } = new Command(async () => await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new DiveLogPage(), true));
        public ICommand DiveSitePage { get; private set ; } = new Command( async () => await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new DiveSitesPage()));
        public ICommand MessageBoardPage { get; private set; } = new Command(async () => await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new MessageBoardPage(), true));
        public ICommand SettingsPage { get; private set; } = new Command(async () => await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new SettingsPage(), true));

        public RootPageViewModel()
        {
            
        }
    }
}
