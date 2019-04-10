using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiveLogger.Utils;
using DiveLogger.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiveLogger.Views.Account
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public LoginPage ()
		{
			InitializeComponent ();
            BindingContext = new LoginViewModel();
		}

        private void BtnLogIn_Clicked(object sender, EventArgs e)
        {
            (BindingContext as LoginViewModel).LogIn();
        }
    }
}