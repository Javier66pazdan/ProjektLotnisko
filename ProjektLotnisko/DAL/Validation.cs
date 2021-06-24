using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ProjektLotnisko.DbClasses;

namespace ProjektLotnisko.DAL
{
    class Validation
    {
        public bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public bool isUserValid(User user)
        {
            bool test=false;
             test = user.GetType().GetProperties()
                .Where(a => a.GetValue(user) is string)
                .Select(a => (string)a.GetValue(user))
                .Any(value => String.IsNullOrEmpty(value));
            return test;
        }
    }
}
