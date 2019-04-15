using DiveLogger.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DiveLogger.Utils;
using System;
using Xamarin.Essentials;

namespace DiveLogger
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DataBaseConnection.Connect();
            CheckForFireBaseAuthToken();
            //MainPage = new NavigationPage(new RootPage());
        }

        protected override void OnStart()
        {
            
        }

        private async void CheckForFireBaseAuthToken()
        {
            FireBaseAuthUtil auth = new FireBaseAuthUtil();
            try
            {
                string token = Settings.FirebaseAuthJson;
                if (!string.IsNullOrEmpty(token)) { 
                    await auth.Login("init", "init");
                    //await Navigation.PushModalAsync(new RootPage());
                    MainPage = new NavigationPage( new RootPage());
                }
                else
                {
                    MainPage = new Auth();
                }
            }
            catch (Firebase.Auth.FirebaseAuthException e)
            {
                MainPage = new Auth();
            }
            catch (Exception e)
            {
                MainPage = new Auth();
            }
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
