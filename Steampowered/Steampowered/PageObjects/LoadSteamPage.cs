﻿using System;
using System.IO;
using System.Linq;
using System.Threading;
using Framework;
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
        private string _nameFile;
        private const char SeparatorHref = '/';
        private int _seconds = 0;

        public LoadSteamPage()
        {
            Assert.True(IsTruePage(_btnInstalSteam), "This is not LoadSteamPage");
        }

        public void ClickInstallSteam()
        {
            _btnInstalSteam.Click();         
        }

        public bool CheckFile()
        {
            _nameFile = _btnInstalSteam.GetAttribute("href").Split(SeparatorHref).Last();
            _fullPathToFile = Environment.CurrentDirectory + Config.PathToFile + "\\" + _nameFile;
            while (_seconds < Config.Time)
            {
                if (!IsFileExist())
                {
                    Thread.Sleep(Config.DownloadWait);
                    _seconds++;
                }

                else
                {
                    ClearFolder(Config.PathToFile);
;                   return true;
                }
            }           
            return false;
        }

        public static void ClearFolder(string pathFolder)
        {
            var dirInfo = new DirectoryInfo(Environment.CurrentDirectory + pathFolder);
            foreach (var file in dirInfo.GetFiles())
            {
                file.Delete();
            }
        }

        private bool IsFileExist()
        {
            return File.Exists(_fullPathToFile);
        }
    }
}
