using NUnit.Framework.Legacy;
using OpenQA.Selenium;
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
    public class LanguageTest :CommonDriver
    {

        public readonly IWebDriver driver;
        public LanguageTest(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void AddLanguage(IWebDriver driver, string language, string level)
        {
            Wait.WaitToBeVisible(driver,"XPath", "//div[@data-tab='first']//div[text()='Add New']", 5);

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

        /*public void ClearData(IWebDriver driver) 
        {
            try
            {
                var deleteButtons = driver.FindElements(By.XPath("//td[@class='right aligned']//i[@class='remove icon']"));
                foreach (var button in deleteButtons)
                {
                    button.Click();
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Nothing to delete");
            }
              
         }*/

        public void ClearData(IWebDriver driver)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var deleteButtons = wait.Until(drv => drv.FindElements(By.XPath("//td[@class='right aligned']//i[@class='remove icon']")));

                foreach (var button in deleteButtons)
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(button)).Click();
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Nothing to delete");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timed out waiting for elements to be clickable");
            }
        }

        public string GetNewLanguage(IWebDriver driver, string language)
        {   
            //Get New language
            IWebElement newLanguage = driver.FindElement(By.XPath("(//div[text()='Add New']/ancestor::thead/following-sibling::tbody[last()]/tr/td)[1]"));
            return newLanguage.Text;
        }
        public string GetEditedLanguage(IWebDriver driver, string finalvalue)
        {
            //Get Edited language
            IWebElement editedLanguage = driver.FindElement(By.XPath("(//div[text()='Add New']/ancestor::thead/following-sibling::tbody/tr/td)[1]"));
            return editedLanguage.Text;
        }
        public void EditLanguageRecord(IWebDriver driver, string language, string level)
        {
            Wait.WaitToBeClickable(driver,"XPath","//td[@class='right aligned']//i[@class='outline write icon']",3);

            //Click Edit button 
            IWebElement editButton = driver.FindElement(By.XPath("//td[@class='right aligned']//i[@class='outline write icon']"));
            editButton.Click();

            //locate the value (language record) to be edited
            IWebElement valueToBeEdited = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            valueToBeEdited.Clear();
            valueToBeEdited.SendKeys(language);

            //Edit the language level
            IWebElement chooseLanguageLevelDropdown = driver.FindElement (By.XPath("//select[@name='level']"));//(By.Name(initiallevel))
            chooseLanguageLevelDropdown.SendKeys(level);
            //chooseLanguageLevelDropdown.Click();

            //Click on Update button
            IWebElement updateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            updateButton.Click();

        }

        public void DeleteLanguageRecord(IWebDriver driver)
        {
            Wait.WaitToBeClickable(driver,"XPath","//td[@class='right aligned']//i[@class='remove icon']",3);

            //Click Delete button
            IWebElement deleteButton = driver.FindElement(By.XPath("//td[@class='right aligned']//i[@class='remove icon']"));
            deleteButton.Click();

        }
    }
}


