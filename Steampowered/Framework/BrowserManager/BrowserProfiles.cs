using System;
using Framework.Configurations;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Framework.BrowserManager
{
    public static class BrowserProfiles
    {
        public static FirefoxOptions GetFireFoxProfile()
        {
            var profile = new FirefoxOptions();
            profile.SetPreference("browser.download.folderList", 2);
            profile.SetPreference("browser.download.dir", Environment.CurrentDirectory + Config.PathToFile);
            profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream");
            profile.SetPreference("browser.download.manager.showWhenStarting", false);
            return profile;
        }

        public static ChromeOptions GetChromeProfile()
        {
            var profile = new ChromeOptions();
            profile.AddUserProfilePreference("download.prompt_for_download", false);
            profile.AddUserProfilePreference("download.default_directory", Environment.CurrentDirectory + Config.PathToFile);
            profile.AddUserProfilePreference("safebrowsing.enabled", true);
            return profile;
        }
    }
}
