using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAMars.Utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMars.Pages
{
    public class Skill : CommonDriver
    {
        private static IWebElement addSkillButton => driver.FindElement(By.XPath("//div[@data-tab='second']//div[text()='Add New']"));
        private static IWebElement addSkillTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        private static IWebElement chooseSkillLevelDropdown => driver.FindElement(By.XPath("//select[@name='level']"));
        private static IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement newSkill => driver.FindElement(By.XPath("(//div[@data-tab='second']//tbody//td[1])[last()]"));
        private static IWebElement editSkillButton => driver.FindElement(By.XPath("//div[@data-tab='second']//td[@class='right aligned']//i[@class='outline write icon']"));
        private static IWebElement SkillToBeEdited => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        private static IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement deleteButton => driver.FindElement(By.XPath("(//div[@data-tab='second']//i[@class='remove icon'])"));


        public void AddSkill(string skill, string level)
        {

            Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='second']//div[text()='Add New']", 3);

            //Click on Add skill button
            addSkillButton.Click();

            //Click on Add Skill Textbox
            addSkillTextbox.SendKeys(skill);

            //Choose skill level
            chooseSkillLevelDropdown.SendKeys(level);
            chooseSkillLevelDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Add']", 3);

            //Click on Add button
            addButton.Click();
            Thread.Sleep(3000);


        }
        
            public void ClearSkill()
            {

                try
                {
                    var deleteButtons = driver.FindElements(By.XPath("//div[@data-tab='second']//td[@class='right aligned']//i[@class='remove icon']"));

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
        
        public string GetNewSkill(string skill)
        {
            Wait.WaitToBeVisible(driver, "XPath", "(//div[@data-tab='second']//tbody//td[1])[last()]", 3);
            return newSkill.Text;
        }

        public void EditSkillRecord(string updatedskill, string updatedlevel)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='second']//td[@class='right aligned']//i[@class='outline write icon']", 3);

            //Click Edit button
            editSkillButton.Click();

            //locate and update the value to be edited
            SkillToBeEdited.Clear();
            SkillToBeEdited.SendKeys(updatedskill);

            //Edit the skill level
           chooseSkillLevelDropdown.SendKeys(updatedlevel);

            //Click on Update button
            updateButton.Click();
            Thread.Sleep(3000);

        }

        public void DeleteSkillRecord(string skill)
        {
            Wait.WaitToBeClickable(driver, "XPath", "(//div[@data-tab='second']//i[@class='remove icon'])", 3);
            deleteButton.Click();
            Thread.Sleep(3000);

        }
    }
}