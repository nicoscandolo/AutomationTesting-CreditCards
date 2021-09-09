using CreditCards.AutomationTesting.Waits;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CreditCards.AutomationTesting.PageObjectModels
{
    class HomePage : Page
    {
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new FluentWait(Driver).Wait();
        }

        protected override string PageUrl => "http://localhost:44108/";
        protected override string PageTitle => "Home Page - Credit Cards";
        public void ClickFooterLink() => Driver.FindElement(By.Id("ContactFooter")).Click();

        public FormCreditCardPage ClickGreetingLink()
        {
            IWebElement greetingLink = Driver.FindElement(By.PartialLinkText("- Apply Now!"));
            greetingLink.Click();
            return new FormCreditCardPage(Driver);
        }

        public  FormCreditCardPage ClickApplyEasyApplicationLink()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Easy: Apply Now!"))).Click();

            return new FormCreditCardPage(Driver);
        }
    }
}
