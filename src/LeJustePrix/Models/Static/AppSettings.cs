using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeJustePrix.Models.Static
{
    public static class AppSettings
    {
        public static string APP_VERSION_BUILD => System.Configuration.ConfigurationManager.AppSettings.Get("APP_VERSION_BUILD");
        public static int MIN => Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("MIN"));
        public static int MAX => Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("MAX"));
    }
}
