using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static PhorestSalon_TechTest.Constants.Contants;
using static PhorestSalon_TechTest.Constants.TestContext;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;

namespace PhorestSalon_TechTest.StepDefinitions
{
    [Binding]
    public class StepDefinitionBase
    {
        private static TestContext _testContext;

        public StepDefinitionBase(TestContext testContext)
        {
            _testContext = testContext;
        }

        [BeforeScenario]
        public static void DeleteAllCookies()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }


        [BeforeTestRun]
        private static void BeforeTestRun()
        {
            InitBrowser(browser);
                      
        }

        private static void InitBrowser(BrowserName BrowserName)
        {
            switch (BrowserName)
            {

                case BrowserName.EdgeBrowser:
                    driver = new EdgeDriver();
                    break;
                case BrowserName.FireFoxBrowser:
                    break;
            }
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(15));
        }


        [AfterTestRun]
        public static void AfterTestRun()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
            driver = null;
        }

    }
}
