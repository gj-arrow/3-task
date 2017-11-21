using Framework.Elements;
using OpenQA.Selenium;

namespace Steampowered.Elements
{
    public class Tab : BaseElement
    {
        private const string TemplateTabStr = @"//../../../../..//div[@id='{0}']";

        public Tab(By locator) : base (locator)
        {
        }

        public Tab(By locator, string name) : base (locator, name)
        {
        }

        public string GetInnerHtml(string idTab)
        {
            WaitUntilDisplayed();
            var locatorTab = string.Format(TemplateTabStr, idTab);
            var locatorToDiscountGames = GetInnerElement(By.XPath(locatorTab)).GetAttribute("innerHTML");
            return locatorToDiscountGames;
        }
    }
}
