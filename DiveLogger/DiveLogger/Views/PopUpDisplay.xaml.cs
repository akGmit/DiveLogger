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
	public partial class PopUpDisplay : ContentPage
	{
		public PopUpDisplay ()
		{
			InitializeComponent ();
		}

        public async Task DisplayPopUpAsync(string title, string msg, string btn)
        {
            await DisplayAlert(title, msg, btn);
        }
	}
}