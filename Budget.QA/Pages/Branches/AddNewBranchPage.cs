using System.Collections.Generic;
using Budget.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using static Budget.Helpers.Utils;
using static Budget.Enums.Messages;

namespace Budget.Pages.Branches
{
    public class AddNewBranchPage : BranchesPage
    {
        public AddNewBranchPage(IWebDriver driver, bool shouldWait = true) : base(driver, false)
        {
            if (!shouldWait) return;
            WaitUntilElementExists(Driver, By.XPath("//h1[contains(text(),'Filia ')]"));
        }

        private IWebElement BranchCode => Driver.FindElement(By.XPath("//*[@formcontrolname='account']"));
        private IWebElement Name => Driver.FindElement(By.XPath("//*[@formcontrolname='name']"));
        private IWebElement City => Driver.FindElement(By.XPath("//*[@formcontrolname='city']"));
        private IWebElement ZipCode => Driver.FindElement(By.XPath("//*[@formcontrolname='zipCode']"));
        private IWebElement Street => Driver.FindElement(By.XPath("//*[@formcontrolname='street']"));
        private IWebElement Phone => Driver.FindElement(By.XPath("//*[@formcontrolname='phone']"));
        private IWebElement Fax => Driver.FindElement(By.XPath("//*[@formcontrolname='fax']"));
        private IWebElement DepartmentCode => Driver.FindElement(By.XPath("//*[@formcontrolname='departmentCode']"));
        private IWebElement CompanyCode => Driver.FindElement(By.XPath("//*[@formcontrolname='companyCode']"));

        private IList<IWebElement> AddBtnList =>
            Driver.FindElements(By.XPath("//a[@class='mat-flat-button mat-button-base mat-primary']//span"));

        private IWebElement GenerateBtn => Driver.FindElement(By.XPath("//span[contains(text(),'Generuj ')]"));

        public BranchesPage SaveBranch(Branch branch)
        {
            WaitOnPage(1);
            BranchCode.SendKeys(branch.BranchCode);
            Name.SendKeys(branch.Name);
            City.SendKeys(branch.City);
            ZipCode.SendKeys(branch.ZipCode);
            Street.SendKeys(branch.Street);
            Phone.SendKeys(branch.Phone);
            Fax.SendKeys(branch.Fax);
            DepartmentCode.SendKeys(branch.DepartmentCode);
            CompanyCode.SendKeys(branch.CompanyCode);
            WaitOnPage(1);
            GenerateBtn.Click();
            WaitUntilElementExists(Driver, By.XPath("//*[@class='toast-message ng-star-inserted']"));
            Assert.AreEqual(ToastMessage.Text, BranchAddedSuccessfully);
            return new BranchesPage(Driver);
        }

        public AddPersonsPage GoToPersonsList(int personType = 0)
        {
            WaitOnPage(3);
            AddBtnList[personType].Click();
            return new AddPersonsPage(Driver);
        }
    }
}