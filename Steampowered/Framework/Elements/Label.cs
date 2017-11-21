using OpenQA.Selenium;

namespace Framework.Elements
{
    public class Label : BaseElement
    {
        public Label(By locator) : base(locator)
        {
        }

        public Label(By locator, string name) : base(locator, name)
        { 
        }

        public void ScrollToLabel()
        {
            ScrollToElement();
        }
    }
}
