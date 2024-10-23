using NUnit.Framework;
using OpenQA.Selenium;
using QAMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMars.Pages
{
    public class ProfileHomePage : CommonDriver
    {
        //private readonly IWebDriver driver;
        /*public ProfileHomePage(IWebDriver driver)
        {
            this.driver = driver;

        }*/
        public void NavigatetoLanguageTab()
        {
            try
            {
                IWebElement LanguageTab = driver.FindElement(By.XPath("//a[text()='Languages']"));
                LanguageTab.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to access Language");
            }
        }

        public void NavigateToSkillTab()
        {
            try
            {
                IWebElement SkillTab = driver.FindElement(By.XPath("//a[text()='Skills']"));
                SkillTab.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to access Skill");
            }
            Thread.Sleep(3000);
        }

        public void CheckUser()
        {
            IWebElement checkUser = driver.FindElement(By.XPath("//span[text()='Hi ']"));
            if (checkUser.Text == "Hi nidhi")
            {
                Console.WriteLine("User successfully logged in");
            }
            else
            {
                Console.WriteLine("User not logged in");
            }

        }
    }
}

