using OpenQA.Selenium;

namespace Budget.Pages
{
    public class BudgetBasePage : BasePage
    {
        public BudgetBasePage(IWebDriver driver) : base(driver)
        {
            NavMenu = new Navigation(driver);
        }

        protected IWebElement ToastMessage =>
            Driver.FindElement(By.XPath("//*[@class='toast-message ng-star-inserted']"));

        public Navigation NavMenu { get; }
    }
}