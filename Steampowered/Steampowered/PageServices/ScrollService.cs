using Framework.Elements;
using OpenQA.Selenium;

namespace Steampowered.PageServices
{
   public static class ScrollService
    {
        public static void ScrollToElement(IWebDriver driver, BaseElement element)
        {
            var webElement = driver.FindElement(element.GetLocator);
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
        }
    }
}
