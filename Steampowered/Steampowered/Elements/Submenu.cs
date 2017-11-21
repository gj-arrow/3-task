using Framework.Elements;
using OpenQA.Selenium;

namespace Steampowered.Elements
{
    public class Submenu : BaseElement
    {
        private const string TemplateGenreLocatorStr = "//div[contains(@class, 'popup_menu')]//a[contains(text(),'{0}')]";

        public Submenu(string itemMenu) : base (By.XPath(string.Format(TemplateGenreLocatorStr, itemMenu)))
        {
        }

        public Submenu(string itemMenu, string name) : base (By.XPath(string.Format(TemplateGenreLocatorStr, itemMenu)), name)
        {
        }
    }
}
