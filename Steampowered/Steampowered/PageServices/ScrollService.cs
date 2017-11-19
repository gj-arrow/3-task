using OpenQA.Selenium;
using Steampowered.PageServices;

namespace Steampowered.PageServices
{
   public static class ScrollService
    {
        public static void ScrollToElement(IWebDriver driver, By locator)
        {
            var element = WaitService.WaitUntilElementExists(driver, locator);
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
