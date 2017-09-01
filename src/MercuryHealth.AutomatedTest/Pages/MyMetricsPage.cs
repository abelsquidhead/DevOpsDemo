using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace MercuryHealth.AutomatedTest.Pages
{
    public class MyMetricsPage : BasePage
    {
        public MyMetricsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Actions
        #endregion

        #region Verifications
        public MyMetricsPage VerifyMyMeticsPageReached()
        {
            try
            {
                //var createNewLink = _driver.FindElement(By.XPath("/html/body/div[2]/p/a"));
                var createNewLink = _driver.FindElement(By.LinkText("My Metrics"));
            }
            catch (Exception e)
            {
                Assert.Fail("Could not find create new link and verify my metrics page reached: " + e.Message);
            }

            return this;
        }

        #endregion
    }
}