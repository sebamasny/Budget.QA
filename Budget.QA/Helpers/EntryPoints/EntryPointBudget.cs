using Budget.Pages;
using OpenQA.Selenium;

namespace Budget.Helpers.EntryPoints
{
    public static class EntryPointBudget
    {
        public static BudgetBasePage BasePage(this IWebDriver driver)
        {
            return new BudgetBasePage(driver);
        }

        public static AnnualReportsPage AnnualReportsPage(this IWebDriver driver)
        {
            return new AnnualReportsPage(driver);
        }
    }
}