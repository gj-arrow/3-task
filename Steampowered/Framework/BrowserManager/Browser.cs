using System;
using Framework.Configurations;
using OpenQA.Selenium;

namespace Framework.BrowserManager
{
    public class Browser
    {
        private readonly IWebDriver _driver = BrowserFactory.GetDriver();
        private static Browser _browser;

        private Browser()
        {
        }

        public static Browser GetInstance()
        {
            if (_browser == null)
            {
                _browser = new Browser();
                _browser.WindowMaximize();
                _browser.PageLoadTimeout(Config.ExplicitWait);
                _browser.ImplicityWaitTimeout(Config.ImplicitWait);
            }
            return _browser;
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void ImplicityWaitTimeout(int time)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
        }

        public void PageLoadTimeout(int time)
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(time);
        }

        public string GetTitle()
        {
            return _driver.Title;
        }

        public void WindowMaximize()
        {
            _driver.Manage().Window.Maximize();
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }

        public void CloseDriver()
        {
            _driver.Quit();
        }
    }
}
