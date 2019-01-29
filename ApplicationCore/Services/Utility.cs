using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ApplicationCore.Services
{
    class Utility
    {
        public static string RemoveNonDigits(string str)
        {
            if (!string.IsNullOrEmpty(str))
                return Regex.Replace(str, "[^0-9]", "");
            else
                return str;
        }
    }
}
