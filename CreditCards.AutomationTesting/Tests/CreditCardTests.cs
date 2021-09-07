using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using CreditCards.AutomationTesting.PageObjectModels;

namespace CreditCards.AutomationTesting
{
    public class CreditCardTests: IClassFixture<ChromeDriverFixture>
    {
        private readonly ChromeDriverFixture ChromeDriverFixture;

        public CreditCardTests(ChromeDriverFixture chromeDriverFixture)
        {
            ChromeDriverFixture = chromeDriverFixture;
        }

        [Fact]
        public void ShouldBeSubmittedWhenFormIsValid_ReturnCorrectValues()
        {
            const string FirstName = "Nico";
            const string LastName = "Scandolo";
            const string Number = "123456-B";
            const string Age = "25";
            const string Income = "90000";

            var formCreditCardPage = new FormCreditCardPage(ChromeDriverFixture.Driver);
            formCreditCardPage.NavigateToPage();

            formCreditCardPage.WriteFirstName(FirstName);
            formCreditCardPage.WriteLastName(LastName);
            formCreditCardPage.WriteFrequentFlyerNumber(Number);
            formCreditCardPage.WriteAge(Age);
            formCreditCardPage.WriteGrossIncome(Income);
            formCreditCardPage.ChooseMaritalStatusSingle();
            formCreditCardPage.ChooseInternetOnHearAboutUs();
            formCreditCardPage.AcceptTerms();
            CompletedFormPage completedFormPage = formCreditCardPage.SubmitForm();

            completedFormPage.EnsurePageIsLoaded();

            Assert.NotEmpty(completedFormPage.NumberOfReference);
            Assert.Equal($"{FirstName} {LastName}", completedFormPage.FullName);
            Assert.Equal(Age, completedFormPage.Age);
            Assert.Equal(Income, completedFormPage.Income);
            Assert.Equal("Single", completedFormPage.RelationshipStatus);
            Assert.Equal("Internet", completedFormPage.BussinessSource);
        }


    }
}
