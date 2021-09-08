using CreditCards.AutomationTesting.Waits;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCards.AutomationTesting.PageObjectModels
{
    class FormCreditCardPage : Page
    {

        public FormCreditCardPage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new FluentWait(Driver).Wait();
        }

        protected override string PageUrl => "http://localhost:44108/Apply";
        protected override string PageTitle => "Credit Card Application - Credit Cards";
        public void WriteFirstName(string firstName) => Driver.FindElement(By.Id("FirstName")).SendKeys(firstName);
        public void WriteLastName(string lastName) => Driver.FindElement(By.Id("LastName")).SendKeys(lastName);
        public void WriteFrequentFlyerNumber(string frequentFlyerNumber) => Driver.FindElement(By.Id("FrequentFlyerNumber")).SendKeys(frequentFlyerNumber);
        public void WriteAge(string age) => Driver.FindElement(By.Id("Age")).SendKeys(age);
        public void WriteGrossIncome(string grossIncome) => Driver.FindElement(By.Id("GrossAnnualIncome")).SendKeys(grossIncome);
        public void ChooseMaritalStatusSingle() => Driver.FindElement(By.Id("Single")).Click();
        public void ChooseInternetOnHearAboutUs()
        {
            IWebElement businessSource  = Driver.FindElement(By.Id("BusinessSource"));
            SelectElement bussinessSourceElement = new SelectElement(businessSource);
            bussinessSourceElement.SelectByText("Internet Search");
        }
        public void AcceptTerms() => Driver.FindElement(By.Id("TermsAccepted")).Click();
        public CompletedFormPage SubmitForm()
        {
            Driver.FindElement(By.Id("SubmitApplication")).Click();

            return new CompletedFormPage(Driver);
        }
        public ReadOnlyCollection<string> ValidationErrorMessages
        {
            get
            {
                return Driver.FindElements(
                    By.CssSelector(".validation-summary-errors > ul > li"))
                    .Select(x => x.Text)
                    .ToList()
                    .AsReadOnly();
            }
        }
             

    }
}
