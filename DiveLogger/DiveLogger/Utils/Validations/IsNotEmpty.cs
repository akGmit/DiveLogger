using System;
using System.Collections.Generic;
using System.Text;

namespace DiveLogger.Utils.Validations
{
    public class IsNotEmpty<T> : IValidator<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if(value == null)
            {
                return false;
            }
            var str = value as string;
            return !string.IsNullOrWhiteSpace(str);
        }
    }
}
