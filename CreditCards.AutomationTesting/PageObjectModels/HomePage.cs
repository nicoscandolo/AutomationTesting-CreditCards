using CreditCards.AutomationTesting.Waits;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
