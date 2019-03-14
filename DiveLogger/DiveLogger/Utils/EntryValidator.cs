using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DiveLogger.Utils
{
    public class EntryValidator : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
                if ((int)value > 0)
                    return true;
                else
                    return false;
            
        
        }

        public object Convert(object value, object value2, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as string;
            var str2 = value2 as string;
            return str.Equals(str2) ? true : (object)false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
