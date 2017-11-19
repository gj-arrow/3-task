using OpenQA.Selenium;
using Steampowered.Services;

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
            var btnInstallSteam = WaitService.WaitUntilElementClickable(_driver, _btnInstalSteamLocator);
            btnInstallSteam.Click();
        }

    }
}
