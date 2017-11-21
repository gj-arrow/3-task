using System;
using System.IO;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using Framework.Configurations;
using Framework.Elements;
using NUnit.Framework;

namespace Steampowered.PageObjects
{
    public class LoadSteamPage : BasePage
    {
        private readonly Button _btnInstalSteam = new Button(By.Id("about_install_steam_link"), "btnInstalSteam");
        private string _fullPathToFile;
        private string nameFile;

        public LoadSteamPage()
        {
            Assert.True(IsTruePage(_btnInstalSteam.GetLocator()), "This is not LoadSteamPage");
        }

        public void ClickInstallSteam()
        {
            _btnInstalSteam.Click();
           
        }

        public bool CheckFile()
        {
            nameFile = _btnInstalSteam.GetAttribute("href").Split('/').Last();
            _fullPathToFile = Environment.CurrentDirectory + "\\" + nameFile;
            while (!IsFileExist())
            {
                Thread.Sleep(500);
            }
            File.Delete(_fullPathToFile);
            return true;
        }

        private bool IsFileExist()
        {
            return File.Exists(_fullPathToFile);
        }
    }
}
