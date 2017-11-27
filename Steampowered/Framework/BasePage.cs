using System;
using Framework.BrowserManager;
using Framework.Elements;

namespace Framework
{
    public abstract class BasePage
    {
        protected Browser Browser;

        protected BasePage()
        {
            Browser = Browser.GetInstance();
        }

        protected bool IsTruePage(BaseElement element)
        {
            try
            {
                element.IsExistOnPage();
            }
            catch (Exception e)
            {
                Console.WriteLine("The expected page was not displayed." + e.Message);
                return false;
            }
            return true;
        }
    }
}
