using OpenQA.Selenium;

namespace Framework.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator) : base (locator)
        {
        }

        public Button(By locator, string name) : base(locator, name)
        {
        }
    }
}
