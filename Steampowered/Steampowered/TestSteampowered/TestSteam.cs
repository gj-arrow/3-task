using System;
using System.Globalization;
using System.Threading;
using NUnit.Framework;
using Steampowered.PageObjects;
using Framework.BrowserManager;
using Framework.Configurations;
using Steampowered.Entities;

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
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Config.Language);
            _browserFactory.Driver.Navigate().GoToUrl(Config.Url);
        }

        [TearDown]
        public void Dispose()
        {
            _browserFactory.CloseDriver();
        }

        [Test,Repeat(3)]
        public void AutoTestSteampowered()
        {
            HomePage homePage = new HomePage();
            homePage.SetLocale(Config.Language);
            homePage.NavigateToActionGames();

            GenreGamePage genreGamePage = new GenreGamePage();
            genreGamePage.NavigateToTabDiscounts();
            GameInfo gameInfoExpected = genreGamePage.SelectGameWithMaxDiscount();

            CheckAgePage checkAgePage = new CheckAgePage();
            checkAgePage.ConfirmAge();

            GamePage gamePage = new GamePage();
            GameInfo gameInfoActual = gamePage.GetPriceAndDiscount();
            Assert.True(GameInfo.Equals(gameInfoExpected, gameInfoActual),"not match prices or discount");
            gamePage.ClickDownloadSteam();

            LoadSteamPage loadSteamPage = new LoadSteamPage();
            loadSteamPage.ClickInstallSteam();
            Thread.Sleep(10000);
            Assert.True(loadSteamPage.CheckFileInFolder());
        }
    }
}
