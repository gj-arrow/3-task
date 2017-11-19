using System;
using System.IO;
using OpenQA.Selenium;
using Steampowered.Configurations;
using Steampowered.PageServices;

namespace Steampowered.PageObjects
{
    public class LoadSteamPage
    {
        private readonly IWebDriver _driver;
        private readonly By _btnInstalSteamLocator = By.Id("about_install_steam_link");

        public LoadSteamPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickInstallSteam()
        {
           // qwe();
            var btnInstallSteam = WaitService.WaitUntilElementClickable(_driver, _btnInstalSteamLocator);
            btnInstallSteam.Click();
        }

        public bool CheckFileOn()
        {
            var exist = File.Exists(@"D:\Student\Downloads\SteamSetup.exe");
            File.Delete(@"D:\Student\Downloads\SteamSetup.exe");
            return exist;
        }

        //public void ClickInstallSteam()
        //{
        //    var btnInstallSteam = WaitService.WaitUntilElementClickable(_driver, _btnInstalSteamLocator);
        //    btnInstallSteam.Click();
        //    WebClient client = new WebClient();
        //    client.DownloadFileCompleted += new AsyncCompletedEventHandler(Done);
        //    client.DownloadFileAsync(new Uri("https://steamcdn-a.akamaihd.net/client/installer/SteamSetup.exe"), "D:\\Student\\Downloads" + "\\SteamSetup.exe");
        //}

        //private void Done(object sender, AsyncCompletedEventArgs e)
        //{
        //    _driver.Navigate().GoToUrl(Config.Url);
        //}

        //public void qwe()
        //{
        //    FileSystemWatcher watcher = new FileSystemWatcher(@"D:\Student\Downloads\chrome");
        //    /* Watch for changes in LastAccess and LastWrite times, and
        //       the renaming of files or directories. */
        //    watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
        //                           | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        //    // Only watch text files.
        //    //watcher.Filter = "*.exe";

        //    // Add event handlers.
        //    watcher.Changed += new FileSystemEventHandler(OnEnd);
        //    watcher.Created += new FileSystemEventHandler(OnChanged);

        //    // Begin watching.
        //    watcher.EnableRaisingEvents = true;
        //}
        //private  void OnChanged(object source, FileSystemEventArgs e)
        //{
        //    // Specify what is done when a file is changed, created, or deleted.
        //    _driver.Navigate().GoToUrl(Config.Url);
        //}

        //private  void OnEnd(object source, FileSystemEventArgs e)
        //{

        //}

    }
}
