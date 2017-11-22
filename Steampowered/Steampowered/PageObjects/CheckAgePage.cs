using OpenQA.Selenium;
using Framework.Configurations;
using Framework.Elements;

namespace Steampowered.PageObjects
{
    public class CheckAgePage : BasePage
    {
        private readonly SelectElement _selectDay = new SelectElement(By.Name("ageDay"), "selectDay");
        private readonly SelectElement _selectMonth = new SelectElement(By.Name("ageMonth"), "selectMonth");
        private readonly SelectElement _selectYear = new SelectElement(By.Name("ageYear"), "selectYear");
        private readonly Button _btnConfirm = new Button(
            By.XPath("//form[@id='agecheck_form']//span[contains(text(),'" + Resources.Resource.submit + "')]"), "btnConfirmCheckAge");
        private readonly Button _btnOpenPage = new Button(
            By.XPath("//div[@id='app_agegate']//span[contains(text(),'" + Resources.Resource.openPage + "')]"), "btnOpenPage");

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
