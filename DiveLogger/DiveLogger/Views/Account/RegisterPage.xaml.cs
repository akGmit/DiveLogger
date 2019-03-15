using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiveLogger.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiveLogger.Views.Account
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
            BindingContext = new RegisterViewModel();
		}

        private void BtnRegister_Clicked(object sender, EventArgs e)
        {
            (BindingContext as RegisterViewModel).RegisterUserAsync();
        }

        private void MatchPassword(object sender, FocusEventArgs e)
        {
            (BindingContext as RegisterViewModel).MatchPass();
        }

        private void EntryRegConfirmPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}