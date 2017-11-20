using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Framework.BrowserManager;
using Framework.Configurations;

namespace Framework.Elements
{
    public class BaseElement
    {
        protected static  BrowserFactory Bowser = BrowserFactory.GetInstance();
        protected IWebElement Element;
        protected By Locator;
        protected string Name;
        protected WebDriverWait Wait = new WebDriverWait(Bowser.Driver, TimeSpan.FromSeconds(Config.ExplicitWait));

        public BaseElement(By locator, string name)
        {
            Locator = locator;
            Name = name;
        }

        public BaseElement(By locator)
        {
            this.Locator = locator;
        }

        public BaseElement()
        {
        }

        public string GetName
        {
            get { return Name; }
        }

        public By GetLocator
        {
            get { return Locator; }
        }

        public string GetText
        {
            get { return Element.Text; }
        }

        public IWebElement WaitUntilDisplayed()
        {
            Wait.Until(drv => drv.FindElement(Locator).Displayed && drv.FindElement(Locator).Enabled);
            Element = Bowser.Driver.FindElement(Locator);
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

        public void ClickAndWait()
        {
            Element = WaitUntilClickable();
            Element.Click();
            Wait.Until(ExpectedConditions.StalenessOf(Element));
        }

        public void Click()
        {
            Element = WaitUntilClickable();
            Element.Click();
        }
    }
}
