using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMars.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        //Functions that allow users to Login to QA  mars
        public void LoginActions(IWebDriver driver) 
        {
            //Launch QA mars Portal
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            //Identify Sign in and Click on Sign In
            IWebElement signIn = driver.FindElement(By.XPath("//a[@class='item']"));
            signIn.Click();
            Thread.Sleep(2000);

            //Identify Email address textbox and enter valid email 
            IWebElement emailAddress = driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
            emailAddress.SendKeys("t9nidhi@gmail.com");

            //Identify password textbox and enter valid password 
            IWebElement passwordTextbox = driver.FindElement(By.XPath("//input[@placeholder='Password']"));
            passwordTextbox.SendKeys("Pass@2020");

            //Identify Login Button and Click on it
            IWebElement loginButton = driver.FindElement(By.XPath("//button[@class='fluid ui teal button']"));
            loginButton.Click();
            Thread.Sleep(2000);
            
        }
    }
}
