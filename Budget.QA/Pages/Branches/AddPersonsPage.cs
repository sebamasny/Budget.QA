using System.Collections.Generic;
using OpenQA.Selenium;
using static Budget.Helpers.Utils;

namespace Budget.Pages.Branches
{
    public class AddPersonsPage : AddNewBranchPage
    {
        public AddPersonsPage(IWebDriver driver) : base(driver, false)
        {
            WaitUntilElementExists(Driver,
                By.XPath("//*[@class='mat-checkbox-inner-container mat-checkbox-inner-container-no-side-margin']"));
        }

        private IList<IWebElement> PersonsList =>
            Driver.FindElements(
                By.XPath("//*[@class='mat-checkbox-inner-container mat-checkbox-inner-container-no-side-margin']"));

        private IWebElement ConfirmBtn => Driver.FindElement(By.XPath("//span[contains(text(),'Zatwierdź ')]"));

        public AddNewBranchPage AddPersons(int person = 1)
        {
            WaitOnPage(1);
            PersonsList[person].Click();
            WaitOnPage(1);
            ConfirmBtn.Click();
            WaitOnPage(1);
            return new AddNewBranchPage(Driver);
        }
    }
}