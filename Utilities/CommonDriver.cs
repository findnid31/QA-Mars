using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMars.Utilities

{
    public class CommonDriver
    {

        public static IWebDriver driver;
        
        public void BrowserSetup()
        {
            // Open Chrome Browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        



        public void DeleteAllRecords()
        {
            try
            {
                while (true) // Loop until no more records to delete
                {
                    Wait.WaitToBeClickable(driver, "XPath", "//td[@class='right aligned']//i[@class='remove icon']", 15);
                    IWebElement deleteButton = driver.FindElement(By.XPath("//td[@class='right aligned']//i[@class='remove icon']"));
                    deleteButton.Click();
                    Thread.Sleep(2000); 
                }
            }
            catch (NoSuchElementException)
            {
                // No more records to delete
                Console.WriteLine("All records deleted.");
            }
            catch (Exception ex)
            {
                // Log other exceptions for troubleshooting
                Console.WriteLine($"An error occurred while deleting records: {ex.Message}");
            }
        }


        public void CloseBrowser()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

    }
}