using Framework;
using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using Steampowered.Entities;

namespace Steampowered.PageObjects
{
    public class GamePage : BasePage
    {
        private readonly char[] _charsToTrim = { '-', ' ', '%', '$', 'U', 'S', 'D'};
        private readonly Label _lblDiscount = 
            new Label(By.XPath("//div[@id='game_area_purchase']//div[contains(@class,'discount_pct')]"), "lblDiscount");
        private readonly Label _lblOriginalPrice = 
            new Label(By.XPath("//div[@id='game_area_purchase']//div[contains(@class,'discount_original_price')]"), "lblOriginalPrice");
        private readonly Label _lblDiscountPrice = 
            new Label(By.XPath("//div[@id='game_area_purchase']//div[contains(@class,'discount_final_price')]"), "lblDiscountPrice");
        private readonly Label _lblNameGame1 = 
            new Label(By.XPath("//div[contains(@class, 'game_title_area')]//div[contains(@class, 'apphub_AppName')]"), "lblNameGame");
        private readonly Label _lblNameGame2 =
            new Label(By.XPath("//div[contains(@class,'game_title_area')]/h2[contains(@class,'pageheader')]"), "lblNameGame");
        private readonly Button _btnInstallSteam = 
            new Button(By.XPath("//*[@id='global_action_menu']//a[contains(@class,'header_installsteam_btn_content')]"), "btnInstallSteam");
        private GameInfo gameInfo;
        private Label _lblNameGame;

        public GamePage()
        {
            Assert.True(IsTruePage(_lblDiscount), "This is not GamePage");
        }

        public GameInfo GetPriceAndDiscount()
        {
            if (_lblNameGame1.IsExistOnPage())
            {
                _lblNameGame = _lblNameGame1;
            }
            else if (_lblNameGame2.IsExistOnPage())
            {
                _lblNameGame = _lblNameGame2;
            }

            gameInfo = new GameInfo(_lblNameGame.GetText(),
            _lblDiscount.GetText().Trim(_charsToTrim),
            _lblOriginalPrice.GetText().Trim(_charsToTrim),
            _lblDiscountPrice.GetText().Trim(_charsToTrim));
            return gameInfo;
        
        }

        public void NavigateToDownloadSteam()
        {
            _btnInstallSteam.Click();
        }
    }
}
