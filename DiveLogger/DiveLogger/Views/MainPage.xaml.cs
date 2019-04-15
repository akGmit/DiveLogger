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
    }
}
