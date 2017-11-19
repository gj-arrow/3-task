using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Steampowered.Configurations;
using Steampowered.Helpers;

namespace Steampowered.BrowsersFactory
{
  public class BrowserFactory
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return _driver;
            }
        }

        public static void InitBrowser(string browserName)
        {
            var currentBrowser = GetCurrentBrowser();
            switch (currentBrowser)
            {
                case BrowserNameHelper.BrowserEnum.FIREFOX:
                    {
                        FirefoxOptions profile = new FirefoxOptions();
                        profile.SetPreference("browser.download.folderList", 2);
                        profile.SetPreference("browser.download.dir", @"D:\Student\Downloads");
                        profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream");
                        profile.SetPreference("browser.download.manager.showWhenStarting", false);
                        _driver = new FirefoxDriver(profile);
                    }
                    break;

                case BrowserNameHelper.BrowserEnum.CHROME:
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddUserProfilePreference("download.prompt_for_download", false);
                        options.AddUserProfilePreference("download.default_directory", @"D:\Student\Downloads");
                        options.AddUserProfilePreference("safebrowsing.enabled", true);
                        _driver = new ChromeDriver(options);
                    }
                    break;

                default:
                {
                    throw new Exception("Invalid browser name.");
                }
            }
        }

        private static BrowserNameHelper.BrowserEnum GetCurrentBrowser()
        {
            return (BrowserNameHelper.BrowserEnum)Enum.Parse(typeof(BrowserNameHelper.BrowserEnum),Config.Browser.ToUpper());
        }

        public static void CloseDriver()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
