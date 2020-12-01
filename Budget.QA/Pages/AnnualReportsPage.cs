using System;
using OpenQA.Selenium;
using static Budget.Helpers.Utils;

namespace Budget.Pages
{
    public class AnnualReportsPage : BudgetBasePage
    {
        public AnnualReportsPage(IWebDriver driver) : base(driver)
        {
            WaitUntilElementExists(Driver, By.XPath("//*[contains(text(),' Raporty roczne')]"));
        }

        private IWebElement NewBudgetBtn => Driver.FindElement(By.XPath("//*[@href='#/new-budget']"));

        public AnnualReportsPage GetYear(Models.Budget budget)
        {
            WaitOnPage(1);
            var year = Driver
                .FindElement(By.XPath(
                    "(//table/tbody/tr/td[count(//table/thead/tr/th[.=' Rok budżetowy']/preceding-sibling::th)+1])[1]"))
                .Text;
            var yearToInt = Convert.ToInt32(year);
            var newBudgetYear = yearToInt + 1;
            var yearToString = Convert.ToString(newBudgetYear);
            budget.Year = yearToString;
            return this;
        }

        public NewBudgetPage NewBudget()
        {
            NewBudgetBtn.Click();
            return new NewBudgetPage(Driver);
        }
    }
}