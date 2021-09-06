using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

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
        public void VerifyURLLoaded()
        {
            ChromeDriverFixture.Driver.Navigate().GoToUrl("http://localhost:44108");

            string Title = ChromeDriverFixture.Driver.Title;

            Assert.Equal("Home Page - Credit Cards", Title);

            ChromeDriverFixture.Dispose();
        }



    }
}
