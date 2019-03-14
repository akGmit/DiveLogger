using System;
using System.Collections.Generic;
using System.Text;


namespace DiveLogger.Utils.Validations
{
    public interface IValidator<T>
    {
        string ValidationMessage { get; set; }
        bool Check(T value);
    }
}
