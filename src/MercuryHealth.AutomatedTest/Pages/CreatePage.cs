using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace MercuryHealth.AutomatedTest.Pages
{
    public class CreatePage : BasePage
    {

        public CreatePage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Actions
        public CreatePage SetDescription(string descr)
        {
            try
            {
                var descriptionField = _driver.FindElement(By.Id("Description"));
                descriptionField.Clear();
                descriptionField.SendKeys(descr);
            }
            catch(Exception e)
            {
                Assert.Fail("Could not find description text field: " + e.Message);
            }
            return this;
        }

        public NutritionPage ClickCreateButton()
        {
            try
            {
                var createButton = _driver.FindElement(By.ClassName("btn-default"));
                createButton.Click();
            }
            catch(Exception e)
            {
                Assert.Fail("Could not find the create button: " + e.Message);
            }
            return new NutritionPage(_driver);
        }
        #endregion

        #region Verifications
        public CreatePage VerifyCreatePageReached()
        {
            try
            {
                var createHeader = _driver.FindElement(By.XPath("/html/body/div[2]/h2"));
            }
            catch(Exception e)
            {
                Assert.Fail("Could not find create page header: " + e.Message);
            }
            return this;
        }
        #endregion
    }
}