using OpenQA.Selenium;

namespace Framework.Elements
{
    public class Label : BaseElement
    {
        public Label(By locator) : base(locator)
        {
            WaitUntilDisplayed();
        }

        public Label(By locator, string name) : base(locator, name)
        {
            WaitUntilDisplayed();
        }
    }
}
