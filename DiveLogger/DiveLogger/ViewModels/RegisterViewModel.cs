using System;
using System.ComponentModel;
using System.Windows.Input;
using DiveLogger.Models;
using DiveLogger.Utils;
using Xamarin.Forms;

namespace DiveLogger.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public ICommand RegisterCommad { get; private set; }

        private string username;
        private string password;
        private string passwordConfirm;
        private bool passwordMatch = false;
        public string UserName
        {
            get{ return username; }
            set { SetValue(ref username, value); }
        }
        public string Password
        {
            get { return password; }
            set => SetValue(ref password, value);
        }
        public string PasswordConfirm
        {
            get { return passwordConfirm; }
            set { SetValue(ref passwordConfirm, value); }
        }
        public bool PasswordMatch
        {
            get { return passwordMatch; }
            set { SetValue(ref passwordMatch, value); }
        }

        public void RegisterUserAsync()
        {
            UserModel.user.UserName = username;
            UserModel.user.Password = password;
            if (!DBCollection.Create_User(UserModel.user))
            {
                RegFailedAsync();
            }
            else
            {
                RegistrationSuccessAsync();
            }
        }

        internal void MatchPass()
        {
            if (password != null && passwordConfirm != null)
            {
                if (password.Equals(passwordConfirm))
                {
                    passwordMatch = true;
                    PasswordMatch = true;
                }
                else
                {
                    passwordMatch = false;
                    PasswordMatch = false;
                }
            }
        }

        private async void RegistrationSuccessAsync()
        {
            await App.Current.MainPage.DisplayAlert("Success", "New user account created!", "Continue");
            UserModel.user.StoreUserDetails();
            App.Current.MainPage = new Views.MainPage();
        }

        private async void RegFailedAsync()
        {
            await App.Current.MainPage.DisplayAlert("Failed", "Username already taken!", "Try again");
            username = "";
            password = "";
            passwordConfirm = "";
        }

    }
}

