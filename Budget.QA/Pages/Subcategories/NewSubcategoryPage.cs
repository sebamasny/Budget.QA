using System.Collections.Generic;
using Budget.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using static Budget.Helpers.Utils;
using static Budget.Enums.Messages;

namespace Budget.Pages.Subcategories
{
    public class NewSubcategoryPage : SubcategoriesPage
    {
        public NewSubcategoryPage(IWebDriver driver) : base(driver, false)
        {
            WaitUntilElementExists(Driver, By.XPath("//h1[text()='Nowa podkategoria']"));
        }

        private IWebElement SubcategoryName =>
            Driver.FindElement(By.XPath("//input[@ng-reflect-placeholder='Nazwa podkategorii']"));

        private IWebElement AccountsDd => Driver.FindElement(By.XPath("//div[@class='mat-chip-list-wrapper']"));

        private IList<IWebElement> AccountsList =>
            Driver.FindElements(By.XPath(
                "//div[@class='mat-autocomplete-panel mat-autocomplete-visible ng-star-inserted']//mat-option"));

        private IWebElement AddSubcategoryBtn => Driver.FindElement(By.XPath("//span[text()='Generuj ']"));

        public SubcategoriesPage SaveSubcategory(Category category, int item = 1)
        {
            WaitOnPage(1);
            SubcategoryName.SendKeys(category.Name);
            AccountsDd.Click();
            AccountsList[item].Click();
            AddSubcategoryBtn.Click();
            WaitUntilElementExists(Driver, By.XPath("//*[@class='toast-message ng-star-inserted']"));
            Assert.AreEqual(ToastMessage.Text, CategoryAddedSuccessfully);
            return new SubcategoriesPage(Driver);
        }
    }
}