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

        public void AddSkill(string skill, string level)
        {

            Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='second']//div[text()='Add New']", 3);

            //Click on Add skill button
            IWebElement addSkillButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[text()='Add New']"));
            addSkillButton.Click();

            //Click on Add Skill Textbox
            IWebElement addSkillTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addSkillTextbox.SendKeys(skill);

            //Choose skill level
            IWebElement chooseSkillLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
            chooseSkillLevelDropdown.SendKeys(level);
            chooseSkillLevelDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Add']", 3);

            //Click on Add button
            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();
            Thread.Sleep(3000);


        }
        public void ClearSkill()
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var deleteButtons = driver.FindElements(By.XPath("//div[@data-tab='second']//td[@class='right aligned']//i[@class='remove icon']"));

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
        public string GetNewSkill(string skill)
        {
            Wait.WaitToBeVisible(driver, "XPath", "(//div[@data-tab='second']//tbody//td[1])[last()]", 3);
            IWebElement newSkill = driver.FindElement(By.XPath("(//div[@data-tab='second']//tbody//td[1])[last()]"));
            return newSkill.Text;
        }

        public void EditSkillRecord(string updatedskill, string updatedlevel)
        {
            Thread.Sleep(4000);

            //Click Edit button
            IWebElement editSkillButton = driver.FindElement(By.XPath("//div[@data-tab='second']//td[@class='right aligned']//i[@class='outline write icon']"));
            editSkillButton.Click();

            //locate and update the value to be edited
            IWebElement SkillToBeEdited = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            SkillToBeEdited.Clear();
            SkillToBeEdited.SendKeys(updatedskill);

            //Edit the skill level
            IWebElement chooseSkillLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
            chooseSkillLevelDropdown.SendKeys(updatedlevel);

            //Click on Update button
            IWebElement updateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            updateButton.Click();
            Thread.Sleep(3000);

        }

        public void DeleteSkillRecord(string skill)
        {
            Wait.WaitToBeClickable(driver, "XPath", "(//div[@data-tab='second']//i[@class='remove icon'])", 3);

            IWebElement deleteButton = driver.FindElement(By.XPath("(//div[@data-tab='second']//i[@class='remove icon'])"));
            deleteButton.Click();
            Thread.Sleep(3000);

        }
    }
}