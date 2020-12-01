using OpenQA.Selenium;

namespace Budget.Pages
{
    public class BasePage
    {
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebDriver Driver { get; }
    }
}