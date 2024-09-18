using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace QAMars.Utilities
{
    [Binding]
    public class Hooks : CommonDriver
    {

        public required IWebDriver driver;

        [BeforeScenario()]
        public void BeforeScenario()
        {
            BrowserSetup();
        }


        [AfterScenario]
        public void AfterScenario()
        {
            // Close the browser and dispose of the WebDriver instance
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}

