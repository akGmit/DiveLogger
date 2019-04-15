using DiveLogger.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DiveLogger.Utils;
using System;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DiveLogger
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Auth();
        }

        protected override void OnStart()
        {
            DataBaseConnection.Connect();
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
