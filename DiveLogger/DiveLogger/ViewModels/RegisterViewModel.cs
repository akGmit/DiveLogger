using System;
using System.ComponentModel;
using System.Windows.Input;
using DiveLogger.Utils;
using Xamarin.Forms;

namespace DiveLogger.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private string username;
        private string password;
        private string passwordConfirm;
        private bool passwordMatch = false;
        public string UserName
        {
            get => username;
            set
            {
                if (username == value) return;
                username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string Password
        {
            get => password;
            set
            {
                if (password == value) return;
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string PasswordConfirm
        {
            get => passwordConfirm;
            set
            {
                if (passwordConfirm == value) return;
                passwordConfirm = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public bool PasswordMatch
        {
            get { return passwordMatch; }
            set
            {
                OnPropertyChanged(nameof(PasswordMatch));
            }
        }
        private UserModel user;

        public void RegisterUserAsync()
        {
            user = new UserModel(username, password);
            if (!DBCollection.Create_User(user))
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
            user.StoreLoginDetails();
            App.Current.MainPage = new Views.MainPage();
        }

        private async void RegFailedAsync()
        {
            await App.Current.MainPage.DisplayAlert("Failed", "Username already taken!", "Try again"); 
            username = "";
            password = "";
            passwordConfirm = "";
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                   new PropertyChangedEventArgs(propertyName));
        }
    }
}
