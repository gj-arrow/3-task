using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Steampowered.Configurations;
using Steampowered.PageServices;

namespace Steampowered.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly By _btnGamesLocator = By.XPath("//*[@id='genre_tab']//a[contains(text(),'" + Resources.Resource.menuGames + "')]");
        private readonly By _btnActionGenreLocator = By.XPath("//div[@id='genre_flyout']/div/a[contains(text(),'"+ Resources.Resource.action + "')]");
        private readonly By _btnLanguageLocator = By.Id("language_pulldown");
        private string _templateSelectLanguageLocator = "//*[@id='language_dropdown']/div/a[contains(@href,'{0}')]";

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateHomePage()
        {
            _driver.Navigate().GoToUrl(Config.Url);
        }

        public void NavigateToActionGames()
        {
            var actions = new Actions(_driver);
            var buttonGames = WaitService.WaitUntilElementExists(_driver, _btnGamesLocator);
            actions.MoveToElement(buttonGames).Perform();
            var buttonActionGenre = WaitService.WaitUntilElementClickable(_driver, _btnActionGenreLocator);
            var action = new Actions(_driver);
            action.MoveToElement(buttonActionGenre).Click().Build().Perform();
        }

        public void SelectLanguage(string language)
        {
            var btnLanguages = _driver.FindElement(_btnLanguageLocator);
            btnLanguages.Click();
            var selectedLanguageLocator = By.XPath(GenerateLocatorService.GenerateStringLocator(_templateSelectLanguageLocator, language));
            var btnSelectedLanguage = _driver.FindElements(selectedLanguageLocator);
            if (btnSelectedLanguage.Count != 0)
            {
                WaitService.ClickAndWaitForPageToLoad(_driver, selectedLanguageLocator);
            }
            else
            {
                btnLanguages.Click();
            }
        }
    }
}