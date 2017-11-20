using OpenQA.Selenium;
using Framework.Configurations;
using Framework.Elements;

namespace Steampowered.PageObjects
{
    public class CheckAgePage
    {
        private readonly IWebDriver _driver;
        private readonly SelectElement _selectDay = new SelectElement(By.Name("ageDay"), "selectDay");
        private readonly SelectElement _selectMonth = new SelectElement(By.Name("ageMonth"), "selectMonth");
        private readonly SelectElement _selectYear = new SelectElement(By.Name("ageYear"), "selectYear");
        private readonly Button _btnConfirm = new Button(
            By.XPath("//form[@id='agecheck_form']/a[contains(@class,'btnv6_blue_hoverfade')]"), "btnConfirmCheckAge");
       
        public CheckAgePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ConfirmAge()
        {
            if (_driver.FindElements(By.Name("ageDay")).Count != 0)
            {
                _selectDay.SelectValue(Config.Day);
                _selectMonth.SelectValue(Config.Month);
                _selectYear.SelectValue(Config.Year);
                _btnConfirm.ClickAndWait();
            }
        }
    }
}
