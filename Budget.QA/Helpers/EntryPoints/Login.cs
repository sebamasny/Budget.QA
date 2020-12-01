using NUnit.Framework;
using OpenQA.Selenium;

namespace Budget.Helpers.EntryPoints
{
    public static class Login
    {
        public static void LogBudgetUser(this IWebDriver driver)
        {
            driver.OpenBudgetApp().Log(TestContext.Parameters["UserCode"]);
        }
    }
}