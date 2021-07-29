using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartFormApp.Helpers
{
    static class Validations
    {
        public static bool IsMailValid(string text)
        {
            Regex reg = new Regex(@"^([a-zA-Z0-9]+[a-zA-Z0-9\.]*[a-zA-Z0-9]+)@(mail)\.(ru)$");

            return (reg.IsMatch(text));

        }
        public static bool IsGmailValid(string text)
        {
            Regex reg = new Regex(@"^([a-zA-Z0-9]+[a-zA-Z0-9\.]*[a-zA-Z0-9]+)@(gmail)\.(com)$");

            return (reg.IsMatch(text));

        }
        public static bool IsNameValid(string text)
        {
            if (text.Length >= 4)
            {
                return true;
            }
            return false;
        }
        public static bool IsBirthValid(string text)
        {
            if (text.Length == 10 || text.Length == 8)  
            {
                return true;
            }
            return false;
        }
        

        public static bool IsPhoneValid(string text)
        {
            if (text.Length == 9 || text.Length == 12 || text.Length == 11)
            {
                return true;
            }
            return false;
        }
    }
}
