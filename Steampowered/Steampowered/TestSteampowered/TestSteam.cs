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

        [SetUp]
        public void Initialize()
        {
            _browserFactory = BrowserFactory.GetInstance();
            _browserFactory.InitBrowser(Config.Browser);
            _browserFactory.Driver.Manage().Window.Maximize();
            _browserFactory.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Config.ImplicitWait);
            _browserFactory.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Config.ExplicitWait);
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Config.Language);
        }

        [TearDown]
        public void Dispose()
        {
            _browserFactory.CloseDriver();
        }

        [Test,Repeat(3)]
        public void AutoTestSteampowered()
        {
            HomePage homePage = new HomePage(_browserFactory.Driver);
            homePage.NavigateHomePage();
            homePage.SelectLanguage(Config.Language);
            homePage.NavigateToActionGames();
            GenreGamePage genreGamePage = new GenreGamePage(_browserFactory.Driver);
            genreGamePage.NavigateToTabDiscounts();
            var expectedPriceAndDiscount = genreGamePage.SelectGameWithMaxDiscount();
            CheckAgePage checkAgePage = new CheckAgePage(_browserFactory.Driver);
            checkAgePage.ConfirmAge();
            GamePage gamePage = new GamePage(_browserFactory.Driver);
            var actualPriceAndDiscount = gamePage.GetPriceAndDiscount();
            Assert.AreEqual(expectedPriceAndDiscount[0], actualPriceAndDiscount[0]);
            Assert.AreEqual(expectedPriceAndDiscount[1], actualPriceAndDiscount[1]);
            Assert.AreEqual(expectedPriceAndDiscount[2], actualPriceAndDiscount[2]);
            gamePage.ClickDownloadSteam();
            LoadSteamPage loadSteamPage = new LoadSteamPage(_browserFactory.Driver);
            loadSteamPage.ClickInstallSteam();
            Thread.Sleep(10000);
            Assert.True(loadSteamPage.CheckFileOn());
        }
    }
}
