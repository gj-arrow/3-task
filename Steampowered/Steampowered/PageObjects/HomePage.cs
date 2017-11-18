using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Steampowered.Configurations;
using Steampowered.PageServices;

namespace Steampowered.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly By _btnGamesLocator = By.Id("genre_tab");
        private readonly By _btnActionGenreLocator = By.XPath("//div[@id='genre_flyout']/div/a[contains(text(),'Экшен')]");
        private readonly By _btnLanguageLocator = By.Id("language_pulldown");
        private string _templateSelectLanguageLocator =
            "//*[@id='language_dropdown']/div/a[contains(@href,'{0}')]";

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
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Config.ExplicitWait));
            var actions = new Actions(_driver);
            var buttonGames = wait.Until(ExpectedConditions.ElementToBeClickable(_btnGamesLocator));
            actions.MoveToElement(buttonGames).Perform();
            var buttonActionGenre = wait.Until(ExpectedConditions.ElementToBeClickable(_btnActionGenreLocator));
            var action = new Actions(_driver);
            action.MoveToElement(buttonActionGenre).Click().Build().Perform();
        }

        public void SelectLanguage(string language)
        {
            var btnLanguages = _driver.FindElement(_btnLanguageLocator);
            if (btnLanguages.Text == "язык22")
            {
                btnLanguages.Click();
                var selectedLanguage = _driver.FindElement(By.XPath(
                    GenerateLocatorService.GenerateStringLocator(_templateSelectLanguageLocator, language)));
                selectedLanguage.Click();
            }
            //var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Config.ExplicitWait));
            // var actions = new Actions(_driver);
            // var buttonActionGenre = wait.Until(ExpectedConditions.ElementToBeClickable(_buttonActionGenreLocator));
            // actions.MoveToElement(buttonActionGenre).Click().Build().Perform();
        }
    }
}