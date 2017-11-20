using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Framework.Configurations;

namespace Steampowered.PageServices
{
   public static class WaitService
    {
        public static bool WaitTillElementisDisplayed(IWebDriver driver, By elementLocator)
        {
            var elementDisplayed = false;
            try
            {
                for (var i = 0; i < Config.ExplicitWait; i++)
                {
                    if (Config.ExplicitWait > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.ExplicitWait));
                        wait.Until(drv => drv.FindElement(elementLocator));
                    }
                    elementDisplayed = driver.FindElement(elementLocator).Displayed;
                }
                return elementDisplayed;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }


        public static IWebElement WaitUntilElementClickable(IWebDriver driver, By elementLocator)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.ExplicitWait));
                var element =  wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
                return element;
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
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.ExplicitWait));
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

        public static IWebElement WaitUntilElementExists(IWebDriver driver, By elementLocator)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.ExplicitWait));
                var element = wait.Until(ExpectedConditions.ElementExists(elementLocator));
                return element;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
    }
}
