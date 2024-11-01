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
                    IWebElement deleteButton;

                    try
                    {
                        // Wait for the delete button to be clickable
                        Wait.WaitToBeClickable(driver, "XPath", "(//td[@class='right aligned']//i[@class='remove icon'])[1]", 15);
                      
                        deleteButton = driver.FindElement(By.XPath("(//td[@class='right aligned']//i[@class='remove icon'])[1]"));
                      
                        deleteButton.Click();

                     }
                    catch (NoSuchElementException)
                    {
                        // If the delete button is not found, exit the loop
                        Console.WriteLine("All records deleted.");
                        break;
                    }
                    catch (ElementNotInteractableException)
                    {
                        Console.WriteLine("The delete button is not interactable. It might be hidden or disabled.");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
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