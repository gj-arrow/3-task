using OpenQA.Selenium;

namespace Steampowered.PageServices
{
   public static class ScrollService
    {
        public static void ScrollToElement(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
