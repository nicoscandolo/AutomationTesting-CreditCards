using Xunit;
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
        public void ShouldBeSubmittedWhitValidForm_ReturnCorrectValues()
        {
            const string FirstName = "Nico";
            const string LastName = "Scandolo";
            const string Number = "123456-B";
            const string Age = "25";
            const string Income = "90000";

            //PageObjectModel
            var formCreditCardPage = new FormCreditCardPage(ChromeDriverFixture.Driver);
            formCreditCardPage.NavigateToPage();

            //Fulfill fields
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

            //Assert: the form was submitted successfully and then redirected to Completed Form Page
            Assert.NotEmpty(completedFormPage.NumberOfReference);
            Assert.Equal($"{FirstName} {LastName}", completedFormPage.FullName);
            Assert.Equal(Age, completedFormPage.Age);
            Assert.Equal(Income, completedFormPage.Income);
            Assert.Equal("Married", completedFormPage.RelationshipStatus);
            Assert.Equal("Internet", completedFormPage.BussinessSource);
        }

        [Fact]
        public void ShouldNotBeSubmitted_ThrowError()
        {
            const string FirstName = "Nico";
            const string InvalidAge = "17";

            //PageObjectModel
            var formCreditCardPage = new FormCreditCardPage(ChromeDriverFixture.Driver);
            formCreditCardPage.NavigateToPage();

            //Fulfill fields
            formCreditCardPage.WriteFirstName(FirstName);
            formCreditCardPage.WriteAge(InvalidAge);
            formCreditCardPage.ChooseMaritalStatusSingle();
            formCreditCardPage.ChooseInternetOnHearAboutUs();
            formCreditCardPage.AcceptTerms();
            CompletedFormPage completedFormPage = formCreditCardPage.SubmitForm();

            //Assert that validation failed
            Assert.Equal(4, formCreditCardPage.ValidationErrorMessages.Count);
            Assert.Contains("Please provide a last name", formCreditCardPage.ValidationErrorMessages);
            Assert.Contains("Please provide a frequent flyer number", formCreditCardPage.ValidationErrorMessages);
            Assert.Contains("You must be at least 18 years old", formCreditCardPage.ValidationErrorMessages);
            Assert.Contains("Please provide your gross income", formCreditCardPage.ValidationErrorMessages);
        }

        [Fact]
        public void ShouldFormBeInitiatedFromHomePage_FormPageOpen()
        {
            //PageObjectModel
            var homePage = new HomePage(ChromeDriverFixture.Driver);
            homePage.NavigateToPage();

            //Go to Form
            FormCreditCardPage formCreditCardPage = homePage.ClickGreetingLink();

            //Assert
            formCreditCardPage.EnsurePageIsLoaded();
        }

        [Fact]
        public void ShouldFormBeInitiatedFromCarouselPage_FormPageOpen()
        {
            //PageObjectModel
            var homePage = new HomePage(ChromeDriverFixture.Driver);
            homePage.NavigateToPage();

            //Go to form
            FormCreditCardPage formCreditCardPage = homePage.ClickApplyEasyApplicationLink();

            //Assert
            formCreditCardPage.EnsurePageIsLoaded();
        }
    }
}
