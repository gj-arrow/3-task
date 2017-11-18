using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Steampowered.Configurations;

namespace Steampowered.PageObjects
{
    public class LoadSteamPage
    {
        private readonly IWebDriver _driver;
        private readonly By _btnInstalSteamLocator = By.Id("about_install_steam_link");

        public LoadSteamPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickInstallSteam()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Config.ExplicitWait));
            var btnInstallSteam = wait.Until(ExpectedConditions.ElementToBeClickable(_btnInstalSteamLocator));
            btnInstallSteam.Click();
        }
    }
}
