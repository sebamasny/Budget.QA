using System.Collections.Generic;
using Budget.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using static Budget.Helpers.Utils;

namespace Budget.Pages.Branches
{
    public class BranchesPage : BudgetBasePage
    {
        public BranchesPage(IWebDriver driver, bool shouldWait = true) : base(driver)
        {
            if (!shouldWait) return;
            WaitUntilElementExists(Driver, By.XPath("//*[text()='Kod filii']"));
        }

        private IWebElement AddNewBranchBtn => Driver.FindElement(By.XPath("//*[@href='#/new-branch']"));

        private IWebElement BranchCode =>
            Driver.FindElement(By.XPath("(//div[@class='mat-form-field-infix']//input)[1]"));

        private IWebElement Branch => Driver.FindElement(By.XPath("(//div[@class='mat-form-field-infix']//input)[2]"));
        private IWebElement RowGroup => Driver.FindElement(By.XPath("//tbody[@role='rowgroup']"));
        private IList<IWebElement> BranchList => RowGroup.FindElements(By.TagName("td"));

        public AddNewBranchPage AddNewBranch()
        {
            AddNewBranchBtn.Click();
            return new AddNewBranchPage(Driver);
        }

        public void SearchBranch(Branch branch)
        {
            BranchCode.SendKeys(branch.BranchCode);
            Branch.SendKeys(branch.Name);
            WaitOnPage(1);
            Assert.AreEqual(BranchList[2].Text, branch.Name);
        }
    }
}