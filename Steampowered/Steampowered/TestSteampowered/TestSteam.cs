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

        [Test,Repeat(15)]
        public void AutoTestSteampowered()
        {
            var homePage = new HomePage();
            homePage.SetLocale(Config.Language);
            homePage.Menu.SelectItem(Resources.Resource.action);

            var genreGamePage = new GenreGamePage();
            genreGamePage.NavigateToTabDiscounts();
            GameInfo gameInfoExpected = genreGamePage.SelectGameWithMaxDiscount();

            var checkAgePage = new CheckAgePage();
            checkAgePage.ConfirmAge();

            var gamePage = new GamePage();
            GameInfo gameInfoActual = gamePage.GetPriceAndDiscount();
            Assert.True(GameInfo.Equals(gameInfoExpected, gameInfoActual),"Does not match prices or discount");
            gamePage.ClickDownloadSteam();

            var loadSteamPage = new LoadSteamPage();
            loadSteamPage.ClickInstallSteam();
            Assert.True(loadSteamPage.CheckFile(), "File not download");
        }
    }
}
