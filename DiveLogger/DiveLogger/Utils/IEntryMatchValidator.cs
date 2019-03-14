using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DiveLogger.Utils
{
    public class IEntryMatchValidator
    {

        public string ValidationMessage { get; set; }

        public bool Match(string str, string str2) {
            if(str != str2)
            {
                return false;
            }
            return true;
        }
    }
}
