using System.Threading;
using Framework;
using OpenQA.Selenium;
using Framework.Elements;
using NUnit.Framework;
using Steampowered.Elements;

namespace Steampowered.PageObjects
{
    public class HomePage : BasePage
    {
        private static readonly string CurrentLanguageName = Thread.CurrentThread.CurrentUICulture.EnglishName.ToLower();
        private readonly Button _btnLanguages = new Button(By.Id("language_pulldown"), "btnLanguages");
        private readonly BaseElement _elementHtml = new BaseElement(By.XPath("/html"), "elementHtml");
        private readonly Label _lblBottomHomePage = 
            new Label(By.XPath("//div[@id='content_login']//div[contains(@class,'more_content_title')]"), "lblBottomHomePage");
        private readonly Button _btnLanguage = 
            new Button(By.XPath(string.Format("//div[@id='language_dropdown']/div/a[contains(@href,'{0}')]", CurrentLanguageName)), "btnSelectedLanguage");
        private Menu _menu;

        public HomePage() {
            Assert.True(IsTruePage(_lblBottomHomePage), "This is not HomePage");
        }

        public Menu GetMenu()
        {
            _menu = new Menu();
            return _menu;
        }

        public void SetLocale(string language)
        {
            var selectedLanguage = _elementHtml.GetAttribute("lang");
            if (selectedLanguage != language)
            {
                _btnLanguages.Click();
                _btnLanguage.ClickAndWait();
            }
        }
    }
}