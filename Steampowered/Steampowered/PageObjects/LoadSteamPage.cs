using System;
using System.IO;
using OpenQA.Selenium;
using Framework.Configurations;
using Framework.Elements;

namespace Steampowered.PageObjects
{
    public class LoadSteamPage
    {
        private readonly IWebDriver _driver;
        private readonly Button _btnInstalSteam = new Button(By.Id("about_install_steam_link"), "btnInstalSteam");

        public LoadSteamPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickInstallSteam()
        {
            _btnInstalSteam.Click();
        }

        public bool CheckFileOn()
        {
            var fullPathToFile = Environment.CurrentDirectory + Config.PathToFile + "\\" + Config.NameFile;
            var exist = File.Exists(fullPathToFile);
            File.Delete(fullPathToFile);
            return exist;
        }      
    }
}
