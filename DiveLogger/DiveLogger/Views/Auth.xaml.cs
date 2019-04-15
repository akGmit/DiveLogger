using DiveLogger.Utils;
using DiveLogger.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiveLogger.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Auth : ContentPage
	{
		public Auth ()
		{
            InitializeComponent();
            BindingContext = new AuthViewModel();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AutoLogin();
        }
        /// <summary>
        /// Check for firebase auth token, if exists and valid, load MainPage.
        /// </summary>
        private async void AutoLogin()
        {
            FireBaseAuthUtil auth = new FireBaseAuthUtil();
            try
            {
                await auth.Login("init", "init");
                await Navigation.PushModalAsync(new MainPage());
            }
            catch (Firebase.Auth.FirebaseAuthException e)
            {
            }
            catch (Exception e)
            {
            }
            
            
        }
    }
}