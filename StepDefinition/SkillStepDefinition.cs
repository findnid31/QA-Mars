using NUnit.Framework;
using OpenQA.Selenium;
using QAMars.Pages;
using QAMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace QAMars.StepDefinition
{
    [Binding]
    public class SkillStepDefinition : CommonDriver
    {
        [Given(@"I logged into Mars portal")]
        public void GivenILoggedIntoMarsPortal()
        {
            //login page object initiallization and definition

            LoginPage loginPageObj = new LoginPage(driver);
            loginPageObj.LoginActions(driver);
        }

        [Given(@"I navigate to Skill tab")]
        public void GivenINavigateToSkillTab()
        {
            //Navigate to skill tab

            ProfileHomePage profileHomePageObj = new ProfileHomePage(driver);
            profileHomePageObj.NavigateToSkillTab();

        }

        [When(@"I add a skill ""([^""]*)"" and level ""([^""]*)""")]
        public void WhenIAddASkillAndLevel(string skill, string level)
        {
            //Add skill page object initialization and definition
            Skill SkillPageObj = new Skill(driver);
            SkillPageObj.ClearSkill(driver);
            SkillPageObj.AddSkill(driver, skill, level);
         }

        [Then(@"the new ""([^""]*)"" record should be created successfully")]
        public void ThenTheNewRecordShouldBeCreatedSuccessfully(string skill)
        {
            {
                IWebElement popupMsg = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
                string popupMsgBox = popupMsg.Text;
                Console.Write(popupMsgBox);
                string popupMsgCreate = skill + " has been added to your skills";
                Assert.That(popupMsgBox, Is.EqualTo(popupMsgCreate), "Actual value and expected value donot match");
            }
        }

        [When(@"I add an invalid skill ""([^""]*)"" and invalid level ""([^""]*)""")]
        public void WhenIAddAnInvalidSkillAndInvalidLevel(string invalidskill, string invalidlevel)
        {
            Skill SkillPageObj = new Skill(driver);
            SkillPageObj.AddSkill(driver, invalidskill, invalidlevel);
        }

        [Then(@"the error message should be displayed successfully")]
      
        public void ThenTheErrorMessageShouldBeDisplayedSuccessfully()
        {
            IWebElement popupMsg = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string popupMsgBox = popupMsg.Text;
            Console.Write(popupMsgBox);
            string popupMsgSkill = "Please enter skill and experience level";
            string popupMsgDupSkill = "This skill is already exist in your skill list.";
            Assert.That(popupMsgBox == popupMsgSkill || popupMsgBox == popupMsgDupSkill, "Actual value and expected value donot match");
        }

        [When(@"I edit an existing skill ""([^""]*)"" and level ""([^""]*)""")]
        public void WhenIEditAnExistingSkillAndLevel(string updatedskill, string updatedlevel)
        {
            //Edit Skill record 

            Skill SkillPageObj = new Skill(driver);
            SkillPageObj.EditSkillRecord(driver, updatedskill, updatedlevel);
        }

        [Then(@"the new ""([^""]*)"" record should be displayed successfully")]
        public void ThenTheNewRecordShouldBeDisplayedSuccessfully(string updatedskill)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 3);

            //Verify if confirmation pop up is seen for edit skill 

            IWebElement popupMsg = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            string popupMsgBox = popupMsg.Text;
            Console.Write(popupMsgBox);
            string popupMsgAdd = updatedskill + " has been updated to your skills";
            Assert.That(popupMsgBox, Is.EqualTo(popupMsgAdd), "Actual value and expected value donot match");

        }

        [When(@"I have an existing skill record to delete")]
        public void WhenIHaveAnExistingSkillRecordToDelete()
        {
            //Skill record should be deleted

            Skill SkillPageObj = new Skill(driver);
            SkillPageObj.DeleteSkillRecord(driver);
        }

        [Then(@"the skill record should be deleted successfully")]
        public void ThenTheSkillRecordShouldBeDeletedSuccessfully()
        {
            {
                Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 4);
               
                //Verify if confirmation pop up is seen for delete

                IWebElement delPopupMsg = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
                string popupMsgBox = delPopupMsg.Text;
                Console.Write(delPopupMsg);
                string popupMsgDel = " has been deleted";
                Assert.That(popupMsgBox, Does.Contain(popupMsgDel), "Actual value and expected value donot match");

            } 
        }

     }
}
