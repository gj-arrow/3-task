using Framework;
using Framework.Elements;
using OpenQA.Selenium;

namespace Steampowered.Elements
{
    public class Menu : BasePage
    {
        private Button _btnMenuItem;
        private Button _btnMenuSubItem;
        private string _templateMenuLocator = "//span[contains(@class,'pulldown')]//a[contains(text(),'{0}')]";
        private const string TemplateGenreLocatorStr = "//div[contains(@class, 'popup_menu')]//a[contains(text(),'{0}')]";
        private const string NameBtn = "btnMenuItem";

        private void HoverElement(string itemMenuName)
        {
            _btnMenuItem = new Button(By.XPath(string.Format(_templateMenuLocator, itemMenuName)), NameBtn);
            _btnMenuItem.MoveToElement();
        }

        public void NavigateToMenuItem(string itemMenuName)
        {
            _btnMenuItem = new Button(By.XPath(string.Format(_templateMenuLocator, itemMenuName)), NameBtn);
            _btnMenuItem.ClickAndWait();
        }

        public void NavigateToSubItemSelectedMenuItem(string itemMenuName, string subItemName)
        {
            HoverElement(itemMenuName);
            _btnMenuSubItem = new Button(By.XPath(string.Format(TemplateGenreLocatorStr, subItemName)), "btnMenuSubItem");
            _btnMenuSubItem.ClickAndWait();
        }
    }
}
