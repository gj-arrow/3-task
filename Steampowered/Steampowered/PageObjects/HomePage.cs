using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Framework.Configurations;
using Framework.Elements;
using Steampowered.PageServices;

namespace Steampowered.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private static readonly string CurrentLanguageName = Thread.CurrentThread.CurrentUICulture.EnglishName.ToLower();
        private readonly By _btnGamesLocator = By.XPath("//*[@id='genre_tab']//a[contains(text(),'" + Resources.Resource.menuGames + "')]");
        private readonly By _btnActionGenreLocator = By.XPath("//div[@id='genre_flyout']/div/a[contains(text(),'"+ Resources.Resource.action + "')]");
        private readonly Button _btnLanguages = new Button(By.Id("language_pulldown"), "btnLanguages");
        private readonly Button _btnLanguage = new Button(
            By.XPath(string.Format("//*[@id='language_dropdown']/div/a[contains(@href,'{0}')]", CurrentLanguageName)), "btnSelectedLanguage");

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
            actions.MoveToElement(buttonActionGenre).Click().Build().Perform();
        }

        public void SelectLanguage(string language)
        {        
            var selectedLanguage = _driver.FindElement(By.XPath("/html")).GetAttribute("lang");
            if (selectedLanguage != language)
            {
                _btnLanguages.Click();
                _btnLanguage.ClickAndWait();
            }
        }
    }
}