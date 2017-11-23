using System;
using Framework.BrowserManager;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public abstract class BasePage
    {
        protected BrowserFactory Browser;

        protected BasePage()
        {
            Browser = BrowserFactory.GetInstance();
        }

        protected bool IsTruePage(By locator)
        {
            try
            {
                Browser.Driver.FindElement(locator);
            }
            catch (Exception e)
            {
                Console.WriteLine("This is wrong page." + e.Message);
                return false;
            }
            return true;
        }
    }
}
