using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DiveLogger.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            //Maps initialization code for UWP
            Xamarin.FormsMaps.Init("kpgCqh22Qwq3W2v5tGwV~EOsieMCqDf3DpPfwO3cLZg~Ar8CYRYsxLojhNnDbyzdcHS8CIC-5KHtrh9HpVsrjmCLiwe01G-aENcuQaIN5nOc");

            LoadApplication(new DiveLogger.App());
        }
    }
}
