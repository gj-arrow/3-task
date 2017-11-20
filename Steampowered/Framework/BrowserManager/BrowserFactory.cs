using System;
using Framework.Configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Framework.BrowserManager
{
  public class BrowserFactory
    {
        private static BrowserFactory _instance = null;
        private IWebDriver _driver;

        public IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return _driver;
            }
        }

        public static BrowserFactory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BrowserFactory();
            }
            return _instance;
        }

        public void InitBrowser(string browserName)
        {
            var currentBrowser = GetCurrentBrowser();
            switch (currentBrowser)
            {
                case BrowserType.BrowserEnum.FIREFOX:
                    {
                        _driver = new FirefoxDriver(BrowserProfiles.GetFireFoxProfile());
                    }
                    break;

                case BrowserType.BrowserEnum.CHROME:
                    {
                        _driver = new ChromeDriver(BrowserProfiles.GetChromeProfile());
                    }
                    break;

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

        public void CloseDriver()
        {
            _driver.Quit();
        }
    }
}
