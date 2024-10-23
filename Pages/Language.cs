using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QAMars.Utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace QAMars.Pages
{
    public class LanguageTest : CommonDriver
    {

        public void AddLanguage(string language, string level)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@data-tab='first']//div[text()='Add New']", 5);

            //Click on Add language button
            IWebElement addLanguageButton = driver.FindElement(By.XPath("//div[@data-tab='first']//div[text()='Add New']"));
            addLanguageButton.Click();

            //Click on AddLanguage Textbox
            IWebElement addLanguageTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            addLanguageTextbox.SendKeys(language);

            //Choose language level
            IWebElement chooseLanguageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
            chooseLanguageLevelDropdown.SendKeys(level);
            chooseLanguageLevelDropdown.Click();

            //Click on Add button
            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();
            Thread.Sleep(3000);

        }

        public void ClearData()
        {

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var deleteButtons = driver.FindElements(By.XPath("//td[@class='right aligned']//i[@class='remove icon']"));

                // Check if there are any delete buttons found
                if (deleteButtons.Count == 0)
                {
                    Console.WriteLine("Nothing to delete");
                    return;
                }

                foreach (var button in deleteButtons)
                {
                    // Wait for each button to be clickable
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(button)).Click();
                    Thread.Sleep(5000);
                }
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timed out waiting for elements to be clickable");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        public string GetNewLanguage(string language)
        {
            Wait.WaitToBeVisible(driver, "XPath", "(//div[text()='Add New']/ancestor::thead/following-sibling::tbody[last()]/tr/td)[1]",8);

            //Get New language
            IWebElement newLanguage = driver.FindElement(By.XPath("(//div[text()='Add New']/ancestor::thead/following-sibling::tbody[last()]/tr/td)[1]"));
            return newLanguage.Text;
            Thread.Sleep(3000);
        }
        public string GetEditedLanguage(string finalvalue)
        {
            //Get Edited language
            IWebElement editedLanguage = driver.FindElement(By.XPath("(//div[text()='Add New']/ancestor::thead/following-sibling::tbody/tr/td)[1]"));
            return editedLanguage.Text;
        }
        public void EditLanguageRecord(string language, string level)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//td[@class='right aligned']//i[@class='outline write icon']", 3);

            //Click Edit button 
            IWebElement editButton = driver.FindElement(By.XPath("//td[@class='right aligned']//i[@class='outline write icon']"));
            editButton.Click();

            //locate the value (language record) to be edited
            IWebElement valueToBeEdited = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            valueToBeEdited.Clear();
            valueToBeEdited.SendKeys(language);

            //Edit the language level
            IWebElement chooseLanguageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));//(By.Name(initiallevel))
            chooseLanguageLevelDropdown.SendKeys(level);


            //Click on Update button
            IWebElement updateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            updateButton.Click();
            Thread.Sleep(2000);

        }

        public void DeleteLanguageRecord(string language)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//td[@class='right aligned']//i[@class='remove icon']", 5);

            //Click Delete button
            IWebElement deleteButton = driver.FindElement(By.XPath("//td[@class='right aligned']//i[@class='remove icon']"));
            deleteButton.Click();
            Thread.Sleep(3000);

        }

        
    }
}