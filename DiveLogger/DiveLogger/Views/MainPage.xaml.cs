using System;
using Xamarin.Forms;

namespace DiveLogger.Views
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            CurrentPage = Children[2];
        }

        private async void BtnNavRegister_Clicked(object sender, EventArgs e) 
                => await Navigation.PushAsync(new Account.RegisterPage());

        private async void BtnNavLogIn_Clicked(object sender, EventArgs e) 
            => await Navigation.PushAsync(new Account.LoginPage());
    }
}
