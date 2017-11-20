using System.Threading;
using Framework.Elements;
using Framework.Utils;
using OpenQA.Selenium;
using Steampowered.Entities;
using Steampowered.PageServices;

namespace Steampowered.PageObjects
{
    public class GenreGamePage
    {
        private readonly IWebDriver _driver;
        private Label _lblDiscount;
        private Label _lblOriginalPrice;
        private Label _lblDiscountPrice;
        private const string RegularFindDiscountGame ="[0-9].(?=\\%<\\/div>)";
        private readonly By _buttonDiscountsLocator = By.XPath("//div[@id='tab_select_Discounts']/div[contains(@class,'tab_content')]");
        private readonly By _discountGamesLocator = By.XPath("//div[@id='DiscountsTable']");
        private string _templateDiscountGameLocator =
            "//div[@id='DiscountsRows']//div[contains(@class,'discount_pct') and contains(text(),'{0}')]/../..";
        private string _templateOriginalPriceGameLocator =
            "//div[@id='DiscountsRows']//div[contains(@class,'discount_pct') and contains(text(),'{0}')]/..//div[contains(@class,'discount_original_price')]";
        private string _templateDiscountPriceGameLocator =
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
            Thread.Sleep(500);
        }

        public GameInfo SelectGameWithMaxDiscount()
        {
            var divInnerText = _driver.FindElement(_discountGamesLocator).GetAttribute("innerHTML");
            _discount = RegexUtil.GetMatchMaxInt(RegularFindDiscountGame, divInnerText).ToString();
            _lblDiscount = new Label(By.XPath(string.Format(_templateDiscountGameLocator, _discount)), "labelDiscount");
            _lblOriginalPrice = new Label(By.XPath(string.Format(_templateOriginalPriceGameLocator, _discount)), "labelOriginalPrice");
            _lblDiscountPrice = new Label(By.XPath(string.Format(_templateDiscountPriceGameLocator, _discount)), "labelDiscountPrice");
            var gameInfo = new GameInfo(_discount, _lblOriginalPrice.GetText.Substring(1), _lblDiscountPrice.GetText.Substring(1));
            ScrollService.ScrollToElement(_driver, _lblDiscount);
            _lblDiscount.ClickAndWait();
            // WaitService.ClickAndWaitForPageToLoad(_driver, gameMaxDiscountlocator); // не ту игру
            //var displayed = WaitService.WaitTillElementisDisplayed(_driver, gameMaxDiscountlocator);
            //if (displayed)
            //{
            //    var actions = new Actions(_driver);
            //    var btnGame = _driver.FindElement(gameMaxDiscountlocator);
            //    actions.MoveToElement(btnGame).Click().Build().Perform();
            //}
            return gameInfo;
        } 
    }
}
