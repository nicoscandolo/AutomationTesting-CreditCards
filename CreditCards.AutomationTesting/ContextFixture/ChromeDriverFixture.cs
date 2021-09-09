using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CreditCards.AutomationTesting
{
    public class ChromeDriverFixture
    {
        public IWebDriver Driver { get; private set; }

        public ChromeDriverFixture()
        {
            Driver = new ChromeDriver();
        }

        public void Dispose()
        {
            Driver.Dispose();
        }

    }
}
