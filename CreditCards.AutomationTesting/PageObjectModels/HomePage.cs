using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCards.AutomationTesting.PageObjectModels
{
    class HomePage
    {
        protected IWebDriver Driver;

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void ClickFooterLink() => Driver.FindElement(By.Id("ContactFooter")).Click();





    }
}
