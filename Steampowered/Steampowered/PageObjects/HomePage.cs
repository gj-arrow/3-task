using System.Threading;
using OpenQA.Selenium;
using Framework.Elements;
using NUnit.Framework;
using Steampowered.Elements;

namespace Steampowered.PageObjects
{
    public class HomePage : BasePage
    {
        private static readonly string CurrentLanguageName = Thread.CurrentThread.CurrentUICulture.EnglishName.ToLower();
        private static readonly By BtnGamesLocator = By.XPath("//div[@id='genre_tab']//a[contains(text(),'" + Resources.Resource.menuGames + "')]");
        private readonly Button _btnLanguages = new Button(By.Id("language_pulldown"), "btnLanguages");
        private readonly Label _lblBottomHomePage = 
            new Label(By.XPath("//div[@id='content_login']//div[contains(@class,'more_content_title')]"), "lblBottomHomePage");
        private readonly Button _btnLanguage = 
            new Button(By.XPath(string.Format("//div[@id='language_dropdown']/div/a[contains(@href,'{0}')]", CurrentLanguageName)), "btnSelectedLanguage");
        private readonly Menu _menu = new Menu(BtnGamesLocator, "menu");

        public HomePage() {
            Assert.True(IsTruePage(_lblBottomHomePage.GetLocator()), "This is not HomePage");
        }

        public void NavigateToActionGames()
        {
            _menu.SelectItem(Resources.Resource.action);
        }

        public void SetLocale(string language)
        {
            var selectedLanguage = GetAttribute(By.XPath("/html"), "lang");
            if (selectedLanguage != language)
            {
                _btnLanguages.Click();
                _btnLanguage.ClickAndWait();
            }
        }
    }
}