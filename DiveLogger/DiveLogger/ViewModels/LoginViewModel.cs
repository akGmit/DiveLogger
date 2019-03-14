using DiveLogger.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveLogger.ViewModels
{
    class LoginViewModel
    {
        private UserModel user;
        private string password;
        private string username;

        public string Password
        { set
            {
                if (password == value) return;
                password = value;
            }
        }

        public string UserName
        {
            set
            {
                if (username == value) return;
                username = value;
            }
        }

        public void LogIn()
        {
            user = new UserModel(username, password);
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
            user.StoreLoginDetails();
            App.Current.MainPage = new Views.MainPage();
        }
    }
}
