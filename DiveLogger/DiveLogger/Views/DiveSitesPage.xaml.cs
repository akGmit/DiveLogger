using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiveLogger.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace DiveLogger.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DiveSitesPage : ContentPage
	{
        
        public DiveSitesPage ()
		{
			InitializeComponent ();
            BindingContext = new DiveSitesViewModel();
        }
    }
}