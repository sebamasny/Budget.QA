using Budget.Pages.Branches;
using Budget.Pages.Subcategories;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using static Budget.Helpers.Utils;

namespace Budget.Pages
{
    public class Navigation : BasePage
    {
        public Navigation(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement ManagementBtn => Driver.FindElement(By.XPath("//*[text()='Zarządzanie']"));
        private IWebElement Branches => Driver.FindElement(By.XPath("//*[text()=' Filie ']"));
        private IWebElement SubCategories => Driver.FindElement(By.XPath("//*[text()=' Podkategorie ']"));

        public Navigation OpenManagementTab()
        {
            var actions = new Actions(Driver);
            actions.MoveToElement(ManagementBtn).Perform();
            return this;
        }

        public BranchesPage BranchesList()
        {
            WaitUntilElementIsClickable(Driver, Branches);
            ClickDestLink(Branches, "branches");
            return new BranchesPage(Driver);
        }

        public SubcategoriesPage SubcategoriesList()
        {
            WaitUntilElementIsClickable(Driver, SubCategories);
            ClickDestLink(SubCategories, "subcategories");
            return new SubcategoriesPage(Driver);
        }

        private void ClickDestLink(IWebElement element, string url)
        {
            var i = 0;
            do
            {
                element.Click();
                i++;
            } while (!Driver.Url.Contains(url) & (i < 20));
        }
    }
}