using System;
using System.Configuration;

namespace Framework.Configurations
{
    public static class Config
    {
        public static string Browser {
            get { return ConfigurationManager.AppSettings["Browser"].ToUpper(); }
        }

        public static string Url
        {
            get { return ConfigurationManager.AppSettings["Url"]; }
        }

        public static int ImplicitWait
        {
            get { return Int32.Parse(ConfigurationManager.AppSettings["ImplicitWait"]); }
        }

        public static int ExplicitWait
        {
            get { return Int32.Parse(ConfigurationManager.AppSettings["ExplicitWait"]); }
        }

        public static string Language
        {
            get { return ConfigurationManager.AppSettings["Language"].ToLower(); }
        }

        public static string PathToFile
        {
            get { return ConfigurationManager.AppSettings["PathToFile"]; }
        }

        public static string NameFile
        {
            get { return ConfigurationManager.AppSettings["NameFile"]; }
        }

        public static string Day
        {
            get { return ConfigurationManager.AppSettings["Day"]; }
        }

        public static string Month
        {
            get { return ConfigurationManager.AppSettings["Month"]; }
        }

        public static string Year
        {
            get { return ConfigurationManager.AppSettings["Year"]; }
        }
    }
}
