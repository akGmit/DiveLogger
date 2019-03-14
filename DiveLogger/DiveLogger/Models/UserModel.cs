using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace DiveLogger.ViewModels
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public void StoreLoginDetails()
        {
            Preferences.Set("UserName", UserName);
            Preferences.Set("Password", Password);
            Preferences.Set("Valid", "true");
        }
    }
}
