using DiveLogger.Utils;
using DiveLogger.ViewModels;
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
	public partial class Auth : ContentPage
	{
		public Auth ()
		{
            InitializeComponent();
            BindingContext = new AuthViewModel();
		}
    }
}