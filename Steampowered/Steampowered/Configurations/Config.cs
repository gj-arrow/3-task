using System;
using System.Configuration;

namespace Steampowered.Configurations
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
    }
}
