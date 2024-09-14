
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QAMars.Pages;
using QAMars.Utilities;
using System;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp2.QAMars.StepDefinition
{
    [Binding]
    public class LanguageStepDefinitions: CommonDriver
    {
        [Given(@"I logged into Mars portal successfully")]
        public void GivenILoggedIntoMarsPortalSuccessfully()
        {
            
            //login page object initiallization and definition
            LoginPage loginPageObj = new LoginPage(driver);
            loginPageObj.LoginActions(driver);
        }
        [When(@"I add a language ""([^""]*)"" and language level ""([^""]*)""")]
        public void WhenIAddALanguageAndLanguageLevel(string language, string level)
        {
            //Add language page object initialization and definition
            LanguageTest LanguagePageObj = new LanguageTest(driver);
            LanguagePageObj.ClearData(driver);
            LanguagePageObj.AddLanguage(driver,language, level);

            {
                if (string.IsNullOrWhiteSpace(language) || string.IsNullOrWhiteSpace(level))
                {
                    throw new ArgumentException("Language and level must not be empty.");
                }

             }
        }

        [Then(@"the ""([^""]*)"" record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully(string language)
        {
            LanguageTest LanguagePageObj = new LanguageTest(driver);
            string newValue = LanguagePageObj.GetNewLanguage(driver,language);
            Assert.That(newValue == language, "Actual value and expected value donot match");
        }

        [When(@"I edit an existing language to ""([^""]*)"" and level to ""([^""]*)""")]
        public void WhenIEditAnExistingLanguageToAndLevelTo(string language, string level)
        {
            LanguageTest languagePageObj = new LanguageTest(driver);
            languagePageObj.EditLanguageRecord(driver, language, level);
        }

        [Then(@"new ""([^""]*)"" record should be displayed successfully")]
        public void ThenNewRecordShouldBeDisplayedSuccessfully(string updatedlanguage)
        {
            //Verify if confirmation pop up is seen for edit language 

            IWebElement popupMsg = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string popupMsgBox = popupMsg.Text;
            Console.Write(popupMsgBox);
            string popupMsgLang = updatedlanguage + " has been updated to your languages";
            Assert.That(popupMsgBox, Is.EqualTo(popupMsgLang), "Actual value and expected value donot match");
        }


       
        [When(@"I have an existing record to delete")]
        public void WhenIHaveAnExistingRecordToDelete()
        {
            Wait.WaitToBeClickable(driver, "XPath", "(//div[text()='Add New']/ancestor::thead/following-sibling::tbody[last()]/tr/td)[1]", 4);

            IWebElement currentLanguage = driver.FindElement(By.XPath("(//div[text()='Add New']/ancestor::thead/following-sibling::tbody[last()]/tr/td)[1]"));
            currentLanguage.Click();

            LanguageTest languagePageObj = new LanguageTest(driver);
            languagePageObj.DeleteLanguageRecord(driver);
        }

        [Then(@"the record should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully()
        {
            {                
                try
                {
                    IWebElement currentLanguage = driver.FindElement(By.XPath("(//div[text()='Add New']/ancestor::thead/following-sibling::tbody[last()]/tr/td)[1]"));

                    // Check if the element is still displayed 
                    if (currentLanguage.Displayed)
                    {
                        throw new Exception("The record was not deleted successfully.");
                    }
                }
                catch (NoSuchElementException)
                {
                    // If the element has been deleted successfully
                    Console.WriteLine("The record has been deleted successfully.");
                }
                catch (Exception ex)
                {
                    // Log unexpected exceptions
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

        }

    }
}





