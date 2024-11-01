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
        private static IWebElement addLanguageButton => driver.FindElement(By.XPath("//div[@data-tab='first']//div[text()='Add New']"));
        private static IWebElement addLanguageTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private static IWebElement chooseLanguageLevelDropdown => driver.FindElement(By.XPath("//select[@name='level']"));
        private static IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement newLanguage => driver.FindElement(By.XPath("(//div[text()='Add New']/ancestor::thead/following-sibling::tbody[last()]/tr/td)[1]"));
        private static IWebElement editedLanguage => driver.FindElement(By.XPath("(//div[text()='Add New']/ancestor::thead/following-sibling::tbody/tr/td)[1]"));
        private static IWebElement editButton => driver.FindElement(By.XPath("//td[@class='right aligned']//i[@class='outline write icon']"));
        private static IWebElement valueToBeEdited => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private static IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement deleteButton => driver.FindElement(By.XPath("//td[@class='right aligned']//i[@class='remove icon']"));

        public void ClearData()
        {

            try
            {
                var deleteButtons = driver.FindElements(By.XPath("//td[@class='right aligned']//i[@class='remove icon']"));

                foreach (var button in deleteButtons)
                {
                    button.Click();
                    Thread.Sleep(5000);
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Nothing to delete");
            }

        }

        public void AddLanguage(string language, string level)
        {
            
            Wait.WaitToBeVisible(driver, "XPath", "//div[@data-tab='first']//div[text()='Add New']", 4);

            //Click on Add language button
             addLanguageButton.Click();

            //Click on AddLanguage Textbox
            
            Wait.WaitToBeVisible(driver, "XPath", "//input[@placeholder='Add Language']", 4);
            addLanguageTextbox.SendKeys(language);
           //Choose language level
            chooseLanguageLevelDropdown.SendKeys(level);
            chooseLanguageLevelDropdown.Click();

            //Click on Add button
             addButton.Click();
            Thread.Sleep(3000);

        }
               


        public string GetNewLanguage(string language)
        {
           // Wait.WaitToBeVisible(driver, "XPath", "(//div[text()='Add New']/ancestor::thead/following-sibling::tbody[last()]/tr/td)[1]",8);

            //Get New language
            return newLanguage.Text;
            Thread.Sleep(3000);
        }
        public string GetEditedLanguage(string finalvalue)
        {
            //Get Edited language
            return editedLanguage.Text;
        }
        public void EditLanguageRecord(string language, string level)
        {
            //Wait.WaitToBeClickable(driver, "XPath", "//td[@class='right aligned']//i[@class='outline write icon']", 3);

            //Click Edit button 
            editButton.Click();

            //locate the value (language record) to be edited
            valueToBeEdited.Clear();
            valueToBeEdited.SendKeys(language);

            //Edit the language level
            chooseLanguageLevelDropdown.SendKeys(level);

            //Click on Update button
            updateButton.Click();
            Thread.Sleep(2000);

        }

        public void DeleteLanguageRecord(string language)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//td[@class='right aligned']//i[@class='remove icon']", 5);

            //Click Delete button
            deleteButton.Click();
            Thread.Sleep(3000);

        }

        
    }
}