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
	public partial class MessageBoardPage : ContentPage
	{
		public MessageBoardPage()
		{
            InitializeComponent();
            BindingContext = new MessageBoardViewModel();
		}
    }
}