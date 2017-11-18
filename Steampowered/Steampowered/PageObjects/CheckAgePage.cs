using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Steampowered.Configurations;

namespace Steampowered.PageObjects
{
    public class CheckAgePage
    {
        private readonly IWebDriver _driver;
        private  readonly By _btnConfirmlocator = By.XPath("//form[@id='agecheck_form']/a[contains(@class,'btnv6_blue_hoverfade')]");

        public CheckAgePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateHomePage()
        {
            _driver.Navigate().GoToUrl(Config.Url);
        }

        public void ConfirmAge()
        {
            if (_driver.FindElements(By.Name("ageDay")).Count != 0)
            {
                SelectElement daySelect = new SelectElement(_driver.FindElement(By.Name("ageDay")));
                daySelect.SelectByText("25");
                SelectElement monthSelect = new SelectElement(_driver.FindElement(By.Name("ageMonth")));
                monthSelect.SelectByIndex(7);
                SelectElement yearSelect = new SelectElement(_driver.FindElement(By.Name("ageYear")));
                yearSelect.SelectByText("1995");
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Config.ExplicitWait));
                var btnConfirm = wait.Until(ExpectedConditions.ElementToBeClickable(_btnConfirmlocator));
                btnConfirm.Click();
            }
        }
    }
}
