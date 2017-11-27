using System;
using Framework.Configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Framework.BrowserManager
{
  public class BrowserFactory
    {
        public static IWebDriver GetDriver()
        {
            var currentBrowser = GetCurrentBrowser();
            switch (currentBrowser)
            {
                case BrowserType.BrowserEnum.FIREFOX:
                    {
                        return new FirefoxDriver(BrowserProfiles.GetFireFoxProfile());
                    }

                case BrowserType.BrowserEnum.CHROME:
                    {
                        return new ChromeDriver(BrowserProfiles.GetChromeProfile());
                    }

                default:
                {
                    throw new Exception("Invalid browser name.");
                }
            }
        }

        private static BrowserType.BrowserEnum GetCurrentBrowser()
        {
            return (BrowserType.BrowserEnum)Enum.Parse(typeof(BrowserType.BrowserEnum),Config.Browser.ToUpper());
        }
    }
}
