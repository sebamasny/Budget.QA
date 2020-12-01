using System.Collections.Generic;
using OpenQA.Selenium;
using static Budget.Helpers.Utils;

namespace Budget.Pages
{
    public class NewBudgetPage : BudgetBasePage
    {
        public NewBudgetPage(IWebDriver driver) : base(driver)
        {
            WaitUntilElementExists(Driver, By.XPath("//h1[contains(text(),'Generuj nowy rok budżetowy')]"));
        }

        //Basic Settings Section
        private IWebElement BudgetYear => Driver.FindElement(By.XPath("//input[@placeholder='Rok budżetowy']"));
        private IWebElement StartDate => Driver.FindElement(By.XPath("//input[@placeholder='Data rozpoczęcia']"));
        private IWebElement EndDate => Driver.FindElement(By.XPath("//input[@placeholder='Data zakończenia']"));

        //Relay Values Section
        private IWebElement EuroExchangeRate => Driver.FindElement(By.XPath("//input[@placeholder='Kurs euro']"));
        private IWebElement DollarExchangeRate => Driver.FindElement(By.XPath("//input[@placeholder='Kurs dolara']"));
        private IWebElement InflationLevel => Driver.FindElement(By.XPath("//input[@placeholder='Poziom inflacji']"));

        private IEnumerable<IWebElement> NumbersList =>
            Driver.FindElements(By.XPath("(//input[@type='number'])[position()>4]"));

        //Budget Form Section
        private IEnumerable<IWebElement> ValidationList =>
            Driver.FindElements(By.XPath("//div[@class='mat-select-trigger']"));

        private IList<IWebElement> ValidationOptionsList =>
            Driver.FindElements(By.XPath("//*[@class='mat-option-text']"));

        private IEnumerable<IWebElement> BudgetLimitsList =>
            Driver.FindElements(By.XPath("//input[@ng-reflect-name='value']"));

        private IWebElement GenerateBtn => Driver.FindElement(By.XPath("//span[text()='Generuj ']"));

        private IWebElement Loader =>
            Driver.FindElement(By.XPath("//p[contains(text(),'Trwa generowanie raportu...')]"));

        public NewBudgetPage FillBasicData(Models.Budget budget)
        {
            BudgetYear.Clear();
            BudgetYear.SendKeys(budget.Year);
            WaitOnPage(1);
            StartDate.SendKeys("01.01." + budget.Year);
            StartDate.Clear();
            StartDate.SendKeys("01.01." + budget.Year);
            EndDate.SendKeys("31.12." + budget.Year);
            EndDate.Clear();
            EndDate.SendKeys("12.31." + budget.Year);
            return this;
        }

        public NewBudgetPage FillValuesSection(Models.Budget budget)
        {
            EuroExchangeRate.Clear();
            EuroExchangeRate.SendKeys(budget.Euro);
            DollarExchangeRate.Clear();
            DollarExchangeRate.SendKeys(budget.Dollar);
            InflationLevel.Clear();
            InflationLevel.SendKeys(budget.Inflation);
            return this;
        }

        public NewBudgetPage WorkingDays(string days = "20")
        {
            foreach (var number in NumbersList)
            {
                number.Clear();
                number.SendKeys(days);
            }

            return this;
        }

        public NewBudgetPage Limits(Models.Budget budget)
        {
            foreach (var limits in BudgetLimitsList) limits.SendKeys(budget.Limit);

            return this;
        }

        public NewBudgetPage Validation(string status)
        {
            foreach (var validation in ValidationList)
            {
                validation.Click();
                var index = ValidationOptionsList.IndexOf(
                    Driver.FindElement(By.XPath("//..//span[text()='" + status + "']")));
                ValidationOptionsList[index].Click();
            }

            return this;
        }

        public void Generate()
        {
            GenerateBtn.Click();
            WaitUntilElementNotExist(Driver, Loader, 700);
        }
    }
}