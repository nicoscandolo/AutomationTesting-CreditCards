using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CreditCards.AutomationTesting.Waits
{
    public class FluentWait
    {
        IWebDriver Driver;
        public FluentWait(IWebDriver driver)
        {
            Driver = driver;
        }

        public WebDriverWait Wait(int sec = 60)
        {
            WebDriverWait wait = new WebDriverWait(Driver, timeout: TimeSpan.FromSeconds(sec))
            {
                PollingInterval = TimeSpan.FromSeconds(5),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return wait;
        }
    }
}
