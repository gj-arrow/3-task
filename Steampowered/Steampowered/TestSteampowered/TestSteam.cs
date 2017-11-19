using System;
using System.Threading;
using NUnit.Framework;
using Steampowered.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Steampowered.BrowsersFactory;
using Steampowered.Configurations;

namespace Steampowered.TestSteampowered
{
    public class TestSteam
    {
        private IWebDriver _driver;
        private string currentLanguageName;

        [SetUp]
        public void Initialize()
        {
            BrowserFactory.InitBrowser(Config.Browser);
            _driver = BrowserFactory.Driver;
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Config.ImplicitWait);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Config.ImplicitWait);
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Config.Language);
            currentLanguageName = Thread.CurrentThread.CurrentUICulture.EnglishName.ToLower();
        }

        [TearDown]
        public void Dispose()
        {
            BrowserFactory.CloseDriver();
        }

        [Test,Repeat(5)]
        public void AutoTestSteampowered()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.NavigateHomePage();
            homePage.SelectLanguage(currentLanguageName);
            homePage.NavigateToActionGames();
            GenreGamePage genreGamePage = new GenreGamePage(_driver);
            genreGamePage.NavigateToTabDiscounts();
            var expectedPriceAndDiscount = genreGamePage.SelectGameWithMaxDiscount();
            CheckAgePage checkAgePage = new CheckAgePage(_driver);
            checkAgePage.ConfirmAge();
            GamePage gamePage = new GamePage(_driver);
            var actualPriceAndDiscount = gamePage.GetPriceAndDiscount();
            for (var item = 0; item < expectedPriceAndDiscount.Count; item++)
            {
                Assert.AreEqual(expectedPriceAndDiscount[item], actualPriceAndDiscount[item]);
            }
            gamePage.ClickDownloadSteam();
            LoadSteamPage loadSteamPage = new LoadSteamPage(_driver);
            loadSteamPage.ClickInstallSteam();
            Thread.Sleep(10000);
            Assert.True(loadSteamPage.CheckFileOn());
        }
    }
}
