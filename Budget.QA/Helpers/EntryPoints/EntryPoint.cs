using Budget.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Budget.Helpers.EntryPoints
{
    public static class EntryPoint
    {
        public static LoginPage OpenBudgetApp(this IWebDriver driver)
        {
            var url = TestContext.Parameters["BudgetApp"];
            driver.Navigate().GoToUrl(url);
            return new LoginPage(driver);
        }
    }
}