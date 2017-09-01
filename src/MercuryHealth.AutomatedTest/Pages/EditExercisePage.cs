using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace MercuryHealth.AutomatedTest.Pages
{
    public class EditExercisePage : BasePage
    {
        public EditExercisePage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Actions
        public EditExercisePage SetEquipment(string equipment)
        {
            try
            {
                var carbTextbox = _driver.FindElement(By.Id("Equipment"));
                carbTextbox.Clear();
                carbTextbox.SendKeys(equipment);
            }
            catch(Exception e)
            {
                Assert.Fail("Could not set equipment: " + e.Message);
            }
            
            return this;
        }

        public ExercisePage ClickSaveButton()
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
            return new ExercisePage(_driver);
        }
        #endregion

        #region Verificiations
        public EditExercisePage VerifyEditFoodPageReached()
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