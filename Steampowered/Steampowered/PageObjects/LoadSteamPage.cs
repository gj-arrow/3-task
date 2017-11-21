using System;
using System.IO;
using OpenQA.Selenium;
using Framework.Configurations;
using Framework.Elements;
using NUnit.Framework;

namespace Steampowered.PageObjects
{
    public class LoadSteamPage : BasePage
    {
        private readonly Button _btnInstalSteam = new Button(By.Id("about_install_steam_link"), "btnInstalSteam");

        public LoadSteamPage()
        {
            Assert.True(IsTruePage(_btnInstalSteam.GetLocator()), "This is not LoadSteamPage");
        }

        public void ClickInstallSteam()
        {
            _btnInstalSteam.Click();
        }

        public bool CheckFileInFolder()
        {
            var fullPathToFile = Environment.CurrentDirectory + Config.PathToFile + "\\" + Config.NameFile;
            var exist = File.Exists(fullPathToFile);
            File.Delete(fullPathToFile);
            return exist;
        }      
    }
}
