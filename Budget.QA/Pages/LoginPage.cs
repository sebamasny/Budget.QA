using OpenQA.Selenium;
using static Budget.Helpers.Utils;

namespace Budget.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement UserCode => Driver.FindElement(By.Id("userCode"));
        private IWebElement Submit => Driver.FindElement(By.XPath("(//input[@value='Zatwierdź'])[2]"));
        private IWebElement LoginBtn => Driver.FindElement(By.XPath("//*[@class='mat-button-wrapper']"));
        private IWebElement Loader => Driver.FindElement(By.XPath("//*[@mode='indeterminate']"));

        public void Log(string code)
        {
            UserCode.Clear();
            UserCode.SendKeys(code);
            Submit.Click();
            WaitUntilElementNotExist(Driver, Loader);
        }
    }
}