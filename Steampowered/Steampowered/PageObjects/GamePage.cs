using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Steampowered.Configurations;

namespace Steampowered.PageObjects
{
    public class GamePage
    {
        private readonly IWebDriver _driver;
        private readonly By _originalPriceGameLocator = By.XPath("//div[@id='game_area_purchase']//div[contains(@class,'discount_original_price')]");
        private readonly By _discountPriceGameLocator = By.XPath("//div[@id='game_area_purchase']//div[contains(@class,'discount_final_price')]");
        private readonly By _discountGameLocator =
            By.XPath("//div[@id='game_area_purchase']//div[contains(@class,'discount_pct')]");
        private readonly By _installSteamLocator =
            By.XPath("//*[@id='global_action_menu']//a[contains(@class,'header_installsteam_btn_content')]");

        public GamePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public List<string> GetPriceAndDiscount()
        {
            var priceAndDiscount = new List<string>();
          //  var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Config.ExplicitWait));
           // var originalPrice = wait.Until(ExpectedConditions.ElementToBeClickable(_originalPriceGameLocator)).Text;
            var originalPrice = _driver.FindElement(_originalPriceGameLocator).Text;
            var discountPrice = _driver.FindElement(_discountPriceGameLocator).Text;
            var discount = _driver.FindElement(_discountGameLocator).Text;
            priceAndDiscount.Add(originalPrice.Substring(1, originalPrice.Length - 1));
            priceAndDiscount.Add(discountPrice.Substring(1, discountPrice.Length - 5));
            priceAndDiscount.Add(discount.Substring(1, discount.Length - 2));
            return priceAndDiscount;
        }

        public void ClickDownloadSteam()
        {
            var btnInstalSteam = _driver.FindElement(_installSteamLocator);
            btnInstalSteam.Click();
        }

    }
}
