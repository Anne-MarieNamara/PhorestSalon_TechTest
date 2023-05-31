using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PhorestSalon_TechTest.Constants.Contants;

namespace PhorestSalon_TechTest.Constants
{
    public static class TestContext
    {
        public static IWebDriver driver;             
        public static WebDriverWait wait;
        public static BrowserName browser = BrowserName.EdgeBrowser;
    }
}
