using OpenQA.Selenium;
using UISelectElement = OpenQA.Selenium.Support.UI.SelectElement;

namespace Framework.Elements
{
    public class SelectElement : BaseElement
    {
        public SelectElement(By locator) : base (locator)
        {
        }

        public SelectElement(By locator, string name) : base (locator, name)
        {
        }

        public void SelectValue(string value)
        {
            WaitUntilDisplayed();
            var select = new UISelectElement(Element);
            select.SelectByText(value);
        }
    }
}
