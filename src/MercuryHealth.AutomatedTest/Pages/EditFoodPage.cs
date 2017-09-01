using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace MercuryHealth.AutomatedTest.Pages
{
    public class EditFoodPage : BasePage
    {
        public EditFoodPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Actions
        public EditFoodPage SetCarbs(string carbs)
        {
            try
            {
                var carbTextbox = _driver.FindElement(By.Id("CarbohydratesInGrams"));
                carbTextbox.Clear();
                carbTextbox.SendKeys(carbs);
            }
            catch(Exception e)
            {
                Assert.Fail("Could not set carbs: " + e.Message);
            }
            
            return this;
        }

        public NutritionPage ClickSaveButton()
        {
            try
            {
                var saveButton = _driver.FindElement(By.ClassName("btn"));
                saveButton.Click();
            }
            catch(Exception e)
            {
                Assert.Fail("Could not click save button: " + e.Message);
            }
            return new NutritionPage(_driver);
        }
        #endregion

        #region Verificiations
        public EditFoodPage VerifyEditFoodPageReached()
        {
            try
            {
                var editHeader = _driver.FindElement(By.TagName("h2"));
                Assert.AreEqual("Edit", editHeader.Text, "page header is not Edit");
            }
            catch(Exception e)
            {
                Assert.Fail("Could not verify edit food page reached: " + e.Message);
            }
            return this;
        }
        #endregion
    }
}