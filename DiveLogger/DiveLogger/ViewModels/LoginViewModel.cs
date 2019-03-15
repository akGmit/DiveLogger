using DiveLogger.Models;
using DiveLogger.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveLogger.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private UserModel user;
        private string password;
        private string username;

        public string Password
        {
            get { return password; }
            set { SetValue(ref password, value); }
        }
        public string UserName
        {
            get { return username; }
            set { SetValue(ref username, value); }
        }

        public void LogIn()
        {
            UserModel.user.UserName = UserName;
            UserModel.user.Password = Password;
            bool isValid = DBCollection.LogIn(user);

            if (isValid) LogInSuccesful();
            else LogInFailedAsync();
        }

        private async void LogInFailedAsync()
        {
            await App.Current.MainPage.DisplayAlert("Failed", "Wrong login details!", "Try again");
            password = "";
            username = "";
        }

        private void LogInSuccesful()
        {
            user.StoreUserDetails();
            App.Current.MainPage = new Views.MainPage();
        }
    }
}
