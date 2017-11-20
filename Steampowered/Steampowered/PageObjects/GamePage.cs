using System.Collections.Generic;
using Framework.Elements;
using OpenQA.Selenium;
using Steampowered.Entities;

namespace Steampowered.PageObjects
{
    public class GamePage
    {
        private readonly IWebDriver _driver;
        private readonly Label _lblDiscount = new Label(By.XPath("//div[@id='game_area_purchase']//div[contains(@class,'discount_pct')]"), "lblDiscount");
        private readonly Label _lblOriginalPrice = new Label(By.XPath("//div[@id='game_area_purchase']//div[contains(@class,'discount_original_price')]"), "lblOriginalPrice");
        private readonly Label _lblDiscountPrice = new Label(By.XPath("//div[@id='game_area_purchase']//div[contains(@class,'discount_final_price')]"), "lblDiscountPrice");
        private readonly Button _btnInstallSteam = new Button(By.XPath("//*[@id='global_action_menu']//a[contains(@class,'header_installsteam_btn_content')]"), "btnInstallSteam");

        public GamePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public GameInfo GetPriceAndDiscount()
        {
            var gameInfo = new GameInfo(_lblDiscount.GetText.Substring(1, _lblDiscount.GetText.Length - 2),
                _lblOriginalPrice.GetText.Substring(1, _lblOriginalPrice.GetText.Length - 1),
                _lblDiscountPrice.GetText.Substring(1, _lblDiscountPrice.GetText.Length - 5));
            return gameInfo;
        }

        public void ClickDownloadSteam()
        {
            _btnInstallSteam.Click();
        }
    }
}
