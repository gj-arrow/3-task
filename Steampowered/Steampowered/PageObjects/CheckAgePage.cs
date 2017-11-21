using OpenQA.Selenium;
using Framework.Configurations;
using Framework.Elements;
using NUnit.Framework;

namespace Steampowered.PageObjects
{
    public class CheckAgePage : BasePage
    {
        private readonly SelectElement _selectDay = new SelectElement(By.Name("ageDay"), "selectDay");
        private readonly SelectElement _selectMonth = new SelectElement(By.Name("ageMonth"), "selectMonth");
        private readonly SelectElement _selectYear = new SelectElement(By.Name("ageYear"), "selectYear");
        private readonly Button _btnConfirm = new Button(
            By.XPath("//form[@id='agecheck_form']/a[contains(@class,'btnv6_blue_hoverfade')]"), "btnConfirmCheckAge");
        private readonly Button _btnOpenPage = new Button(
            By.XPath("//div[@id='app_agegate']//a[contains(@class,'btn_grey_white_innerfade')]"), "btnOpenPage");

        public CheckAgePage()
        {
            Assert.True(Browser.Driver.Url.Contains("agecheck"), "This is not CheckAgePage");
        }

        public void ConfirmAge()
        {
            if (_btnOpenPage.IsExistOnPage())
            {
                _btnOpenPage.Click();
            }

            else if (_selectDay.IsExistOnPage())
            {
                _selectDay.SelectValue(Config.Day);
                _selectMonth.SelectValue(Config.Month);
                _selectYear.SelectValue(Config.Year);
                _btnConfirm.ClickAndWait();
            }
        }
    }
}
