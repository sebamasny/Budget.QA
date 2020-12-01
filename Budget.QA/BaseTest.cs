using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using AutomationResources;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Budget
{
    public abstract partial class BaseTest
    {
        [SetUp]
        public void SetUpBeforeEveryTestMethod()
        {
            Driver = WebDriverFactory.Create(_actualBrowserType);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
        }

        [TearDown]
        public void TearDown()
        {
            ScreenAfterFail();
            CleanUpAfterEveryTestMethod();
        }

        protected IWebDriver Driver { get; private set; }

        private readonly BrowserType _actualBrowserType;

        private readonly WebDriverFactory _driverFactory;

        protected BaseTest(BrowserType browserType)
        {
            _driverFactory = new WebDriverFactory();
            _actualBrowserType = browserType;
        }

        private void ScreenAfterFail()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                if (!status.Equals(TestStatus.Failed)) return;
                var screenshot = Driver.TakeScreenshot();
                var dir = "\\Results\\Screens\\" + TestContext.CurrentContext.Test.Name;
                var nameOfMethod = TestContext.CurrentContext.Test.Name;
                var fileInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory);
                var parentDir = fileInfo.Directory?.Parent?.Parent;
                if (parentDir == null) return;
                var dirPath = parentDir.FullName + dir;
                var fileName = dirPath + "\\" + nameOfMethod + ".png";
                Directory.CreateDirectory(dirPath);
                screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            }
            catch (UnauthorizedAccessException)
            {
                Console.Write("UnauthorizedAccessException: Unable to delete/create folder. ");
            }
        }

        private void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }

        [SetUpFixture]
        public class MySetUpClass
        {
            [OneTimeSetUp]
            public void CreateFolderForScreens()
            {
                const string dir = "\\Results\\";
                var fileInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory);
                var parentDir = fileInfo.Directory?.Parent?.Parent;
                if (parentDir == null) return;
                var dirPath = parentDir.FullName + dir;
                try
                {
                    if (Directory.Exists(dirPath))
                    {
                        Directory.Delete(dirPath, true);
                        Thread.Sleep(100);
                        Directory.CreateDirectory(dirPath + "\\Screens");
                    }
                    else
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("UnauthorizedAccessException: Unable to delete/create folder.");
                }
            }

            [OneTimeTearDown]
            public void CreateZipFromFailedTests()
            {
                const string dir = "\\Results";
                var fileInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory);
                var parentDir = fileInfo.Directory?.Parent?.Parent;
                if (parentDir == null) return;
                var dirPath = parentDir.FullName + dir;
                const string zip = "\\result.zip";
                var zipPath = dirPath + zip;
                var sourcePath = parentDir.FullName + dir + "\\Screens";

                ZipFile.CreateFromDirectory(sourcePath, zipPath);
            }
        }
    }
}