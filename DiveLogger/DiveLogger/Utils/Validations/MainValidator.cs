using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DiveLogger.Utils.Validations
{
    public class MainValidator : IValueConverter
    {
        public string ValidationMessage { get; set; }

        public string username { get; set; }
        public string password { get; set; }
        public string passwordConfirm { get; set; }
          


        public bool Check(String value)
        {
            if (value == null)
            {
                return false;
            }
            var str = value as string;
            return !string.IsNullOrWhiteSpace(str);
        }

        private bool Validate()
        {
            bool isValidUser = ValidateUserName();
            bool isValidPassword = ValidatePassword();
            return isValidUser && isValidPassword;
        }

        public bool MatchValidate(String item1, String item2)
        {
            if (item1 == item2)
                return true;
            return false;
        }

        public bool ValidateUserName()
        {
            return Check(username);
        }

        public bool ValidatePassword()
        {
            return Check(password);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
