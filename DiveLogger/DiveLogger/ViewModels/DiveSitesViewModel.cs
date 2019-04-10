using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace DiveLogger.ViewModels
{
    
    class DiveSitesViewModel : BaseViewModel
    {
        private Map sitesMap;
        public Map SitesMap
        {
            get => sitesMap;
            set => SetValue(ref sitesMap, value);
        }
    }
}
