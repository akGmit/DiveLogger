using DiveLogger.ViewModels;
using DiveLogger.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiveLogger.Views
{
	public partial class DiveLogPage : ContentPage
	{
		public DiveLogPage ()
		{
            InitializeComponent();
            BindingContext = new DiveLogViewModel();
		}
	}
}