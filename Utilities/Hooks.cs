using OpenQA.Selenium;
using System;
using QAMars.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium.DevTools.V126.Storage;
using OpenQA.Selenium.Support.UI;

namespace QAMars.Utilities
{
    [Binding]

    public class Hooks : CommonDriver
    {
        private static IWebDriver driver;
        // private readonly LanguageTest languagePageObj;
        private readonly LoginPage loginPageObj;
        //private readonly Skill skillPageObj;
        private readonly ProfileHomePage profileHomePageObj; 

        public Hooks()
        {
            //languagePageObj = new LanguageTest();
            loginPageObj = new LoginPage();
            profileHomePageObj = new ProfileHomePage();
            //skillPageObj = new Skill();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            BrowserSetup();
            LoginAndDelLanguage();
            DelSkillRecords();
        }

        private void LoginAndDelLanguage()
        {
            loginPageObj.LoginActions();
            DeleteAllRecords();
        }
        private void DelSkillRecords()
        {
            profileHomePageObj.NavigateToSkillTab();
            DeleteAllRecords();

        }


        [AfterScenario]
        public void AfterScenario()
        {

            CloseBrowser();
        }

    }

}

