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
        public readonly IWebDriver driver;
        public Skill(IWebDriver driver)
        {
            this.driver = driver;

        }
        public void AddSkill(IWebDriver driver, string skill, string level)
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
            

        }
        public void ClearSkill(IWebDriver driver)
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
        public string GetNewSkill(IWebDriver driver, string skill)
        {
            Wait.WaitToBeVisible(driver, "XPath", "(//div[@data-tab='second']//tbody//td[1])[last()]", 3);
            IWebElement newSkill = driver.FindElement(By.XPath("(//div[@data-tab='second']//tbody//td[1])[last()]"));
            return newSkill.Text;
        }

        public void EditSkillRecord(IWebDriver driver, string updatedskill, string updatedlevel)
        {
            Thread.Sleep(4000);

            //Click Edit button
            IWebElement editSkillButton = driver.FindElement(By.XPath("(//div[@data-tab='second']//i[@class='outline write icon'])[1]"));
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

        }

        public void DeleteSkillRecord(IWebDriver driver)
        {
            Thread.Sleep(4000);

            IWebElement deleteButton = driver.FindElement(By.XPath("(//div[@data-tab='second']//i[@class='remove icon'])"));
            deleteButton.Click();

        }
    }
}
