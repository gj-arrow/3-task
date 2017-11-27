using Framework;
using Framework.Configurations;
using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using Steampowered.Elements;
using Steampowered.Entities;
using Steampowered.Services;

namespace Steampowered.PageObjects
{
    public class GenreGamePage : BasePage
    {
        private Label _lblDiscount;
        private Label _lblOriginalPrice;
        private Label _lblDiscountPrice;
        private Label _lblNameGame;
        private readonly Label _lblAction = new Label(By.XPath("//div/h2[contains(text(),'" + Resources.Resource.action + "')]"));
        private readonly char[] _charsToTrim = { '-', ' ', '%', '$', 'U', 'S', 'D' };
        private readonly Tab _diacountGamesTab =
            new Tab(By.XPath("//div[@id='tab_select_Discounts']/div[contains(@class,'tab_content')]"), "discountGamesTab");
        private const string RegularFindDiscountGame ="[0-9].(?=\\%<\\/div>)";
        private const string StartLocatorPriceAndDiscount =
            "//div[@id='DiscountsRows']//div[contains(@class,'discount_pct') and contains(text(),'{0}')]/..";
        private const string DiscountGameLocator = StartLocatorPriceAndDiscount + "/..";
        private const string OriginalPriceGameLocator = StartLocatorPriceAndDiscount + "//div[contains(@class,'discount_original_price')]";
        private const string DiscountPriceGameLocator = StartLocatorPriceAndDiscount +  "//div[contains(@class,'discount_final_price')]";
        private const string NameGameLocator = DiscountGameLocator + "//div[contains(@class, 'tab_item_name')]";
        private string _discount;

        public GenreGamePage()
        {
            Assert.True(IsTruePage(_lblAction), "This is not GenreGamePage");
        }

        public void NavigateToTabDiscounts()
        {
            _diacountGamesTab.MoveAndClick();
        }

        public GameInfo SelectGameWithMaxDiscount()
        {
            var divInnerText = _diacountGamesTab.GetInnerHtml(Config.idTab);
           // _discount = RegexService.GetMatchMaxInt(RegularFindDiscountGame, divInnerText).ToString();
            _discount = "50";
            _lblDiscount = new Label(By.XPath(string.Format(DiscountGameLocator, _discount)), "labelDiscount");
            _lblOriginalPrice = new Label(By.XPath(string.Format(OriginalPriceGameLocator, _discount)), "labelOriginalPrice");
            _lblDiscountPrice = new Label(By.XPath(string.Format(DiscountPriceGameLocator, _discount)), "labelDiscountPrice");
            _lblNameGame = new Label(By.XPath(string.Format(NameGameLocator, _discount)), "labelNameGame");
            _lblDiscountPrice.ScrollToLabel();
            var gameInfo = new GameInfo(_lblNameGame.GetText(), _discount, _lblOriginalPrice.GetText().Trim(_charsToTrim), _lblDiscountPrice.GetText().Trim(_charsToTrim));
            _lblDiscount.ClickAndWait();
            return gameInfo;
        } 
    }
}
