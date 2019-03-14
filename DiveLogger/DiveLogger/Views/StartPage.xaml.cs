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
	public partial class StartPage : ContentPage
	{
		public StartPage ()
		{
			InitializeComponent ();
		}

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Account.LoginPage());
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Account.RegisterPage());
        }
    }
}