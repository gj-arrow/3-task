﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Steampowered.Configurations;
using Steampowered.PageServices;
using Steampowered.Services;

namespace Steampowered.PageObjects
{
    public class GenreGamePage
    {
        private readonly IWebDriver _driver;
        private const string RegularFindDiscountGame ="[0-9].(?=\\%<\\/div>)";
        private readonly By _buttonDiscountsLocator = By.XPath("//div[@id='tab_select_Discounts']/div[contains(@class,'tab_content')]");
        private readonly By _discountGamesLocator = By.XPath("//div[@id='DiscountsTable']");
        private string _templateDiscountGameLocator =
            "//div[@id='DiscountsRows']//div[contains(@class,'discount_pct') and contains(text(),'{0}')]/../..";
        private string _templateOriginalPriceGameLocator =
            "//div[@id='DiscountsRows']//div[contains(@class,'discount_pct') and contains(text(),'{0}')]/..//div[contains(@class,'discount_original_price')]";
        private string _templateFinalPriceGameLocator =
            "//div[@id='DiscountsRows']//div[contains(@class,'discount_pct') and contains(text(),'{0}')]/..//div[contains(@class,'discount_final_price')]";
        private string _discount;

        public GenreGamePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToTabDiscounts()
        {
            var buttonDiscounts = WaitService.WaitUntilElementClickable(_driver, _buttonDiscountsLocator);
            buttonDiscounts.Click();
        }

        public List<string> SelectGameWithMaxDiscount()
        {
            var divInnerText = _driver.FindElement(_discountGamesLocator).GetAttribute("innerHTML");
            var discountsGame = new List<int>();
            foreach (Match match in Regex.Matches(divInnerText, RegularFindDiscountGame, RegexOptions.IgnoreCase))
            {
                discountsGame.Add(Int32.Parse(match.Value));
            }
            _discount = discountsGame.Max().ToString();
            var gameMaxDiscountlocator = By.XPath(GenerateLocatorService.GenerateStringLocator(_templateDiscountGameLocator, _discount));
           // var gameMaxDiscount = WaitService.WaitUntilElementClickable(_driver,gameMaxDiscountlocator);
            var priceAndDiscount = GetPriceAndDiscount();
            ScrollService.ScrollToElement(_driver, gameMaxDiscountlocator);
            WaitService.ClickAndWaitForPageToLoad(_driver, gameMaxDiscountlocator);
            //var action = new Actions(_driver);
            //action.MoveToElement(gameMaxDiscount).Click().Build().Perform();
            return priceAndDiscount;
        }

        private List<string> GetPriceAndDiscount()
        {
            var priceAndDiscount = new List<string>();
            var originalPrice = WaitService.WaitUntilElementExists(_driver, By.XPath(GenerateLocatorService.GenerateStringLocator(_templateOriginalPriceGameLocator, _discount))).Text;
            var discountPrice = WaitService.WaitUntilElementExists(_driver,By.XPath(GenerateLocatorService.GenerateStringLocator(_templateFinalPriceGameLocator, _discount))).Text;
            priceAndDiscount.Add(originalPrice.Substring(1));
            priceAndDiscount.Add(discountPrice.Substring(1));
            priceAndDiscount.Add(_discount);
            return priceAndDiscount;
        }
    }
}
