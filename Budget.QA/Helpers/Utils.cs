using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Budget.Helpers
{
    public static class Utils
    {
        public static void WaitUntilElementExists(IWebDriver driver, By by, int timeoutInSeconds = 60)
        {
            Assert.Greater(timeoutInSeconds, 0, "Timeout must be a positive number");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
        }

        public static void WaitUntilElementNotExist(IWebDriver driver, IWebElement element, int timeout = 60)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + element + "' was not found in current context page.");
                throw;
            }
        }

        public static void WaitOnPage(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public static void GoBack(IWebDriver driver)
        {
            driver.Navigate().Back();
        }

        public static void WaitUntilElementIsClickable(IWebDriver driver, IWebElement element,
            int timeoutInSeconds = 30)
        {
            Assert.Greater(timeoutInSeconds, 0, "Timeout must be a positive number");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitForAjaxResponse(IWebDriver driver)
        {
            ((IJavaScriptExecutor) driver).ExecuteScript("return jQuery.active == 0");
        }

        public static string RandomString(int range)
        {
            const string chars = "aąbcćdeęfghijklmnńoópqrsśtuwxyzżźAĄBCĆDEĘEFGIJKLMNŃOÓPQRSŚTUWXYZŻŹ";
            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, range).Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }

        public static string RandomLatinString(int range)
        {
            const string chars = "abcdefghijklmnopqrstuwxyz";
            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, range).Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }

        public static string RandomInt(int range)
        {
            const string chars = "0123456789";
            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, range).Select(s => s[random.Next(s.Length)]).ToArray());
            if (result == "00") result = "1";

            return result;
        }
    }
}