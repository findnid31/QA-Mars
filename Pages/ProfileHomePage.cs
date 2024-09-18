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
        private readonly IWebDriver driver;
        public ProfileHomePage(IWebDriver driver)
        {
            this.driver = driver;

        }
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

        }

        public void VerifyIfUserIsLoggedIn()
        {
            IWebElement Username = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]//div[1]//div[2]//span\r\n")); // write tag name
            if (Username.Text == "hi Nidhi")
            {
                Console.WriteLine("User Logged In successfully");
            }
            else 
            {
                Console.WriteLine("User is Unable to Log In");
            }

        }
        }
    }
