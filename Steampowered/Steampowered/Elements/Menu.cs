using Framework.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Steampowered.Elements
{
    public class Menu : BaseElement
    {
        public Menu(By locator) : base (locator)
        {
        }

        public Menu(By locator, string name) : base (locator, name)
        {
        }

        private void HoverElement()
        {
            WaitUntilDisplayed();
            var mouse = new Actions(Browser.Driver);
            mouse.MoveToElement(Element).Build().Perform();
        }

        public void SelectItem(string itemString)
        {
            HoverElement();
            var subMenuActions = new Submenu(itemString);
            subMenuActions.ClickAndWait();
        }

        public void SelectItem(string itemString, string name)
        {
            HoverElement();
            var subMenuActions = new Submenu(itemString, name);
            subMenuActions.ClickAndWait();
        }
    }
}
