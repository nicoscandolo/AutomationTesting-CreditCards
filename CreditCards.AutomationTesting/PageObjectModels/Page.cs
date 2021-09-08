using CreditCards.AutomationTesting.Waits;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCards.AutomationTesting.PageObjectModels
{
    class Page
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait; 
        protected virtual string PageUrl { get; }
        protected virtual string PageTitle { get; }

        public void NavigateToPage()
        {
            Driver.Navigate().GoToUrl(PageUrl);
            EnsurePageIsLoaded();
        }

        public void EnsurePageIsLoaded(bool VerifyUrlStartsWithExpectedText = true)
        {
            bool urlIsCorrect;
            if (VerifyUrlStartsWithExpectedText)
            {
                urlIsCorrect = Driver.Url.StartsWith(PageUrl);
            }
            else
            {
                urlIsCorrect = Driver.Url == PageUrl;
            }

            bool pageHasLoaded = urlIsCorrect && (Driver.Title == PageTitle);
            if(!pageHasLoaded)
            {
                throw new Exception($"Failed to load page. URL = '{Driver.Url}' Page Source: \r\n {Driver.PageSource}");
            }
        }
    }
}
