using System.Collections.Generic;
using Budget.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using static Budget.Helpers.Utils;

namespace Budget.Pages.Subcategories
{
    public class SubcategoriesPage : BudgetBasePage
    {
        public SubcategoriesPage(IWebDriver driver, bool shouldWait = true) : base(driver)
        {
            if (shouldWait) WaitUntilElementExists(Driver, By.XPath("//h1[text()='Podkategorie']"));
        }

        private IWebElement Name => Driver.FindElement(By.XPath("(//div[@class='mat-form-field-infix']//input)[1]"));
        private IWebElement SubcategoryBtn => Driver.FindElement(By.XPath("//*[@href='#/new-subcategory']"));

        private IWebElement CalculatedSubcategoryBtn =>
            Driver.FindElement(By.XPath("//*[@href='#/new-calculated-subcategory']"));

        private IWebElement RowGroup => Driver.FindElement(By.XPath("//tbody[@role='rowgroup']"));
        private IList<IWebElement> CategoryList => RowGroup.FindElements(By.TagName("td"));

        public NewSubcategoryPage AddNewSubcategory()
        {
            SubcategoryBtn.Click();
            WaitOnPage(1);
            return new NewSubcategoryPage(Driver);
        }

        public void SearchCategory(Category category)
        {
            Name.SendKeys(category.Name);
            WaitOnPage(3);
            Assert.AreEqual(CategoryList[1].Text, category.Name);
        }
    }
}