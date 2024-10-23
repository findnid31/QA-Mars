using NUnit.Framework;
using OpenQA.Selenium;
using QAMars.Pages;
using QAMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace ConsoleApp2.QAMars.StepDefinition
{
    [Binding]
    public class SkillStepDefinition : CommonDriver
    {
       
        ProfileHomePage profileHomePageObj;
        Skill skillPageObj;

        public SkillStepDefinition()
        {
            profileHomePageObj = new ProfileHomePage();
            skillPageObj = new Skill();

        }

        [Given(@"I logged into Mars portal")]
        public void GivenILoggedIntoMarsPortal()
        {
             profileHomePageObj.CheckUser();
        }

        [Given(@"I navigate to Skill tab")]
        public void GivenINavigateToSkillTab()
        {
            //Navigate to skill tab
            profileHomePageObj.NavigateToSkillTab();

        }

        [When(@"I add a skill ""([^""]*)"" and level ""([^""]*)""")]
        public void WhenIAddASkillAndLevel(string skill, string level)
        {
            skillPageObj.AddSkill(skill, level);
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

                // Delete the added skill
                for (int i = 0; i < 1; i++)
                {
                    skillPageObj.DeleteSkillRecord(skill);
                }
            }
        }

        [When(@"I add an invalid skill ""([^""]*)"" and invalid level ""([^""]*)""")]
        public void WhenIAddAnInvalidSkillAndInvalidLevel(string invalidskill, string invalidlevel)
        {
           
            skillPageObj.AddSkill(invalidskill, invalidlevel);
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

        [When(@"I edit an existing ""([^""]*)"" and ""([^""]*)"" to ""([^""]*)"" and level ""([^""]*)""")]
        public void WhenIEditAnExistingAndToAndLevel(string skill, string level, string eskill, string elevel)
        {
            //Edit Skill record 

            profileHomePageObj.NavigateToSkillTab();
            skillPageObj.ClearSkill();
            skillPageObj.AddSkill(skill, level);
            skillPageObj.EditSkillRecord(eskill, elevel);
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
        [When(@"I have a ""([^""]*)"" and ""([^""]*)"" record to delete")]
        public void WhenIHaveAAndRecordToDelete(string skill, string level)
        {
            //Skill record should be deleted

            profileHomePageObj.NavigateToSkillTab();
            skillPageObj.AddSkill(skill, level);
            skillPageObj.DeleteSkillRecord(skill);
        }



        [Then(@"the skill record should be deleted successfully")]
        public void ThenTheSkillRecordShouldBeDeletedSuccessfully()
        {
            {
                Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 5);

                //Verify if confirmation pop up is seen for delete

                IWebElement delPopupMsg = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                string popupMsgBox = delPopupMsg.Text;
                Console.Write(delPopupMsg);
                string popupMsgDel = " has been deleted";
                Assert.That(popupMsgBox, Does.Contain(popupMsgDel), "Actual value and expected value donot match");

            }
        }
        

    }
}