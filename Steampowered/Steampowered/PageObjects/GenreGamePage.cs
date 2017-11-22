using System;
using System.Threading;
using Framework.Configurations;
using Framework.Elements;
using Framework.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Steampowered.Elements;
using Steampowered.Entities;

namespace Steampowered.PageObjects
{
    public class GenreGamePage : BasePage
    {
        private Label _lblDiscount;
        private Label _lblOriginalPrice;
        private Label _lblDiscountPrice;
        private readonly char[] _charsToTrim = { '-', ' ', '%', '$', 'U', 'S', 'D' };
        private readonly Tab _diacountGamesTab =
            new Tab(By.XPath("//div[@id='tab_select_Discounts']/div[contains(@class,'tab_content')]"), "discountGamesTab");
        private const string RegularFindDiscountGame ="[0-9].(?=\\%<\\/div>)";
        private const string StartLocatorPriceAndDiscount =
            "//div[@id='DiscountsRows']//div[contains(@class,'discount_pct') and contains(text(),'{0}')]/..";
        private const string TemplateDiscountGameLocator = StartLocatorPriceAndDiscount + "/..";
        private const string TemplateOriginalPriceGameLocator = StartLocatorPriceAndDiscount + "//div[contains(@class,'discount_original_price')]";
        private const string TtemplateDiscountPriceGameLocator = StartLocatorPriceAndDiscount +  "//div[contains(@class,'discount_final_price')]";
        private string _discount;

        public GenreGamePage()
        {
            Assert.True(IsTruePage(_diacountGamesTab.GetLocator()), "This is not GenreGamePage");
        }

        public void NavigateToTabDiscounts()
        {
            _diacountGamesTab.MoveAndClick();
        }

        public GameInfo SelectGameWithMaxDiscount()
        {
            var divInnerText = _diacountGamesTab.GetInnerHtml(Config.idTab);
            _discount = RegexUtil.GetMatchMaxInt(RegularFindDiscountGame, divInnerText).ToString();
            _lblDiscount = new Label(By.XPath(string.Format(TemplateDiscountGameLocator, _discount)), "labelDiscount");
            _lblOriginalPrice = new Label(By.XPath(string.Format(TemplateOriginalPriceGameLocator, _discount)), "labelOriginalPrice");
            _lblDiscountPrice = new Label(By.XPath(string.Format(TtemplateDiscountPriceGameLocator, _discount)), "labelDiscountPrice");
            _lblDiscountPrice.ScrollToLabel();
            var gameInfo = new GameInfo(_discount, _lblOriginalPrice.GetText().Trim(_charsToTrim), _lblDiscountPrice.GetText().Trim(_charsToTrim));
            _lblDiscount.ClickAndWait();
            return gameInfo;
        } 
    }
}
