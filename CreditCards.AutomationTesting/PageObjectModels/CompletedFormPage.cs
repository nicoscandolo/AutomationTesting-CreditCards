using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCards.AutomationTesting.PageObjectModels
{
    class CompletedFormPage : Page
    {
        public CompletedFormPage(IWebDriver driver)
        {
            Driver = driver;
        }
        protected override string PageUrl => "http://localhost:44108/Apply";
        protected override string PageTitle => "Application Complete - Credit Cards";

        public string NumberOfReference => Driver.FindElement(By.Id("ReferenceNumber")).Text;
        public string FullName => Driver.FindElement(By.Id("FullName")).Text;
        public string Age => Driver.FindElement(By.Id("Age")).Text;
        public string Income => Driver.FindElement(By.Id("Income")).Text;
        public string RelationshipStatus => Driver.FindElement(By.Id("RelationshipStatus")).Text;
        public string BussinessSource => Driver.FindElement(By.Id("BusinessSource")).Text;


    }
}
