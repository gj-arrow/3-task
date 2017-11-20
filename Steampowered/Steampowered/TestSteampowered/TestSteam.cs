using System;
using System.Threading;
using NUnit.Framework;
using Steampowered.PageObjects;
using Steampowered.BrowsersFactory;
using Steampowered.Configurations;

namespace Steampowered.TestSteampowered
{
    public class TestSteam
    {
        private BrowserFactory _browserFactory;
        private string _currentLanguageName;

        [SetUp]
        public void Initialize()
        {
            _browserFactory = BrowserFactory.GetInstance();
            _browserFactory.InitBrowser(Config.Browser);
            _browserFactory.Driver.Manage().Window.Maximize();
            _browserFactory.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Config.ImplicitWait);
            _browserFactory.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Config.ImplicitWait);
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Config.Language);
            _currentLanguageName = Thread.CurrentThread.CurrentUICulture.EnglishName.ToLower();
        }

        [TearDown]
        public void Dispose()
        {
            _browserFactory.CloseDriver();
        }

        [Test,Repeat(5)]
        public void AutoTestSteampowered()
        {
            HomePage homePage = new HomePage(_browserFactory.Driver);
            homePage.NavigateHomePage();
            homePage.SelectLanguage(_currentLanguageName);
            homePage.NavigateToActionGames();
            GenreGamePage genreGamePage = new GenreGamePage(_browserFactory.Driver);
            genreGamePage.NavigateToTabDiscounts();
            var expectedPriceAndDiscount = genreGamePage.SelectGameWithMaxDiscount();
            CheckAgePage checkAgePage = new CheckAgePage(_browserFactory.Driver);
            checkAgePage.ConfirmAge();
            GamePage gamePage = new GamePage(_browserFactory.Driver);
            var actualPriceAndDiscount = gamePage.GetPriceAndDiscount();
            for (var item = 0; item < expectedPriceAndDiscount.Count; item++)
            {
                Assert.AreEqual(expectedPriceAndDiscount[item], actualPriceAndDiscount[item]);
            }
            gamePage.ClickDownloadSteam();
            LoadSteamPage loadSteamPage = new LoadSteamPage(_browserFactory.Driver);
            loadSteamPage.ClickInstallSteam();
            Thread.Sleep(10000);
            Assert.True(loadSteamPage.CheckFileOn());
        }
    }
}
