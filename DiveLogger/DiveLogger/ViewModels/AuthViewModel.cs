using DiveLogger.Utils;
using DiveLogger.Views;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
/// <summary>
/// View model for Auth page. 
/// Log in and Sign up functionality.
/// </summary>
namespace DiveLogger.ViewModels
{
    class AuthViewModel : BaseViewModel
    {
        public ICommand LoginAction { get; private set; }
        public ICommand SignInAction { get; private set; }

        public string Email { get;  set; }
        public string Password { get;  set; }

        public AuthViewModel()
        {
            LoginAction = new Command(LoginAsync);
            SignInAction = new Command(SignupAsync);
        }

        private async void SignupAsync(object obj)
        {
            FireBaseAuthUtil fb = new FireBaseAuthUtil();
            try
            {
                var t = await fb.Register(Email, Password);
                App.Current.MainPage = new MainPage();
            } catch (Firebase.Auth.FirebaseAuthException e)
            {
                await App.Current.MainPage.DisplayAlert("Failed", "Sign up went wrong!\nReason: " + e.Reason, "Try again");
            }
            
        }

        private async void LoginAsync(object obj)
        {
            FireBaseAuthUtil fb = new FireBaseAuthUtil();
            try
            {
                var t = await fb.Login(Email, Password);
                App.Current.MainPage = new MainPage();
            }
            catch (Firebase.Auth.FirebaseAuthException e)
            {
                await App.Current.MainPage.DisplayAlert("Failed", "Log in went wrong!\nReason: " + e.Reason, "Try again");
            }
        }
    }
}
