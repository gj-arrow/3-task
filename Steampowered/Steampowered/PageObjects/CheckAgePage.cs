using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Steampowered.Configurations;
using Steampowered.PageServices;

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

        public void ConfirmAge()
        {
            if (_driver.FindElements(By.Name("ageDay")).Count != 0)
            {
                SelectElement daySelect = new SelectElement(_driver.FindElement(By.Name("ageDay")));
                daySelect.SelectByText(Config.Day);
                SelectElement monthSelect = new SelectElement(_driver.FindElement(By.Name("ageMonth")));
                monthSelect.SelectByIndex(Config.Month);
                SelectElement yearSelect = new SelectElement(_driver.FindElement(By.Name("ageYear")));
                yearSelect.SelectByText(Config.Year);
                var btnConfirm = WaitService.WaitUntilElementClickable(_driver, _btnConfirmlocator);
                btnConfirm.Click();
            }
        }
    }
}
