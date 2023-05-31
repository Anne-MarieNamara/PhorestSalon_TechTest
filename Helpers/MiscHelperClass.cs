using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using static PhorestSalon_TechTest.Constants.TestContext;

namespace PhorestSalon_TechTest.Helpers
{
    public class MiscHelperClass
    {
        public static void ValidateMethod(string actual, string expected)
        {
            MiscHelperClass.WaitForAjax(driver);
            Thread.Sleep(4000);
            Assert.IsTrue(string.Equals(actual, expected, StringComparison.OrdinalIgnoreCase), "Actual :: " + actual + ":: Expected ::" + expected);
        }

        public static void WaitForAjax(IWebDriver driver)
        {
            while (true)
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                string typeJQuery = (string)jse.ExecuteScript("return (typeof jQuery)", "");
                string type = (string)jse.ExecuteScript("return (typeof $)", "");
                if (typeJQuery.Equals("function", StringComparison.CurrentCultureIgnoreCase))
                {
                    bool isAjaxOver = (bool)jse.ExecuteScript("return jQuery.active == 0", "");
                    if (isAjaxOver)
                        break;
                    Thread.Sleep(100);
                }
                else if (type.Equals("function", StringComparison.CurrentCultureIgnoreCase))
                {
                    bool isAjaxOver = (bool)jse.ExecuteScript("return $.active == 0", "");
                    if (isAjaxOver)
                        break;
                    Thread.Sleep(100);
                }
                else
                {
                    Console.WriteLine("Page not loaded properly");
                    return;
                }
            }

            return;
        }
    }
}
