using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Framework.BrowserManager;
using Framework.Configurations;
using OpenQA.Selenium.Interactions;

namespace Framework.Elements
{
    public class BaseElement
    {
        protected static  BrowserFactory Browser = BrowserFactory.GetInstance();
        protected IWebElement Element;
        protected By Locator;
        protected string Name;
        protected WebDriverWait Wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(Config.ExplicitWait));

        protected BaseElement(By locator, string name)
        {
            Locator = locator;
            Name = name;
        }

        protected BaseElement(By locator)
        {
            this.Locator = locator;
        }

        protected BaseElement()
        {
        }

        protected string GetName()
        {
            WaitUntilDisplayed();
            return Name; 
        }

        public By GetLocator()
        {
            WaitUntilDisplayed();
            return Locator; 
        }

        public string GetText()
        {
            WaitUntilDisplayed();
            return Element.Text; 
        }

        public IWebElement WaitUntilDisplayed()
        {
            Wait.Until(drv => drv.FindElement(Locator).Displayed && drv.FindElement(Locator).Enabled);
            Element = Browser.Driver.FindElement(Locator);
            return Element;
        }

        public IWebElement WaitUntilClickable()
        {
            Element = Wait.Until(ExpectedConditions.ElementToBeClickable(Locator));
            return Element;
        }

        public IWebElement WaitUntilElementExists()
        {
            Element = Wait.Until(ExpectedConditions.ElementExists(Locator));
            return Element;
        }

        public IWebElement GetInnerElement(By innerLocator)
        {
            WaitUntilDisplayed();
            var innerElement = Element.FindElement(innerLocator);
            return innerElement;
        }

        public void ClickAndWait()
        {
            WaitUntilClickable();
            Element.Click();
            Wait.Until(ExpectedConditions.StalenessOf(Element));
        }

        public void Click()
        {
            WaitUntilClickable();
            Element.Click();
        }

        public void MoveAndClick()
        {
            ScrollToElement();
            var actions = new Actions(Browser.Driver);
            WaitUntilClickable();
            actions.MoveToElement(Element).Click().Build().Perform();
        }

        public void ScrollToElement()
        {
            var wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(Config.ExplicitWait));
            var webElement = wait.Until(ExpectedConditions.ElementToBeClickable(Locator));
            IJavaScriptExecutor js = Browser.Driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
        }

        public bool IsExistOnPage()
        {
            if (Browser.Driver.FindElements(Locator).Count != 0)
            {
                return true;
            }
            return false;
        }

        public string GetAttribute(string attribute)
        {
            var textAttribute = Element.GetAttribute(attribute);
            return textAttribute;
        }
    }
}
