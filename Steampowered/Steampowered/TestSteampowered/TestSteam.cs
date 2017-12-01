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
        private Browser _browser;

        [SetUp]
        public void Initialize()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Config.Language);
            _browser = Browser.GetInstance();
            _browser.GoToUrl(Config.Url);
            LoadSteamPage.ClearFolder(Config.PathToFile);
        }

        [TearDown]
        public void Dispose()
        {
            _browser.CloseDriver();
        }

        [Test]
        public void AutoTestSteampowered()
        {
            var homePage = new HomePage();
            homePage.SetLocale(Config.Language);
            homePage.GetMenu().NavigateToSubItemSelectedMenuItem(Resources.Resource.menuGames, Resources.Resource.action);

            var genreGamePage = new GenreGamePage();
            genreGamePage.NavigateToTabDiscounts();
            GameInfo gameInfoExpected = genreGamePage.SelectGameWithMaxDiscount();

            var checkAgePage = new CheckAgePage();
            checkAgePage.ConfirmAge();

            var gamePage = new GamePage();
            GameInfo gameInfoActual = gamePage.GetPriceAndDiscount(); 
            Assert.AreEqual(gameInfoExpected, gameInfoActual,"Objects doesn't match.Expected:" 
                + gameInfoExpected + ".Actual:" + gameInfoActual);
            gamePage.NavigateToDownloadSteam();

            var loadSteamPage = new LoadSteamPage();
            loadSteamPage.ClickInstallSteam();
            Assert.True(loadSteamPage.CheckFile(), "File wasn't downloaded");
        }
    }
}
