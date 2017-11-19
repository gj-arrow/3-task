using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Steampowered.Configurations;

namespace Steampowered.Services
{
   public static class WaitService
    {
        public static bool WaitTillElementisDisplayed(IWebDriver driver, By by)
        {
            var elementDisplayed = false;
            for (var i = 0; i < Config.ImplicitWait; i++)
            {
                if (Config.ImplicitWait > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.ImplicitWait));
                    wait.Until(drv => drv.FindElement(by));
                }
                elementDisplayed = driver.FindElement(by).Displayed;
            }
            return elementDisplayed;
        }


        public static IWebElement WaitUntilElementClickable(IWebDriver driver, By elementLocator)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.ImplicitWait));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        public static void ClickAndWaitForPageToLoad(IWebDriver driver, By elementLocator)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.ImplicitWait));
                var element = driver.FindElement(elementLocator);
                element.Click();
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        public static IWebElement WaitUntilElementExists(IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
    }
}
