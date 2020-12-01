using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AutomationResources
{
    public class WebDriverFactory
    {
        public static IWebDriver Create(BrowserType browserType)
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var resourcesDirectory = Path.GetFullPath(Path.Combine(outPutDirectory));

            var headless = TestContext.Parameters["Headless"];
            switch (browserType)
            {
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("no-sandbox", "start-maximized");
                    chromeOptions.AddUserProfilePreference("download.default_directory",
                        outPutDirectory + "\\WindFiles");
                    chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                    chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                    if (headless == "true") chromeOptions.AddArguments("headless", "window-size=1920,1080");
                    return new ChromeDriver(resourcesDirectory, chromeOptions, TimeSpan.FromSeconds(180));
                case BrowserType.InternetExplorer:
                    return new InternetExplorerDriver(resourcesDirectory);
                case BrowserType.Firefox:
                    return new FirefoxDriver(resourcesDirectory);
                default:
                    throw new ArgumentOutOfRangeException("No such browser exists");
            }
        }
    }
}