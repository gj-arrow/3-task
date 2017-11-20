using System.Threading;
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
        private IWebElement qwe;

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
            var selectedLanguage = _driver.FindElement(By.XPath("/html")).GetAttribute("lang");
            if (selectedLanguage != language)
            {
                var btnLanguages = _driver.FindElement(_btnLanguageLocator);
                btnLanguages.Click();
                var currentLanguageName = Thread.CurrentThread.CurrentUICulture.EnglishName.ToLower();
                var selectedLanguageLocator = By.XPath(GenerateLocatorService.GenerateStringLocator(_templateSelectLanguageLocator, currentLanguageName));
                WaitService.ClickAndWaitForPageToLoad(_driver, selectedLanguageLocator);
            }
        }
    }
}