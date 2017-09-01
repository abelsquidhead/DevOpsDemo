using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace MercuryHealth.AutomatedTest.Pages
{
    public class NutritionPage : BasePage
    {
        public NutritionPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Actions
        public CreatePage ClickCreateNewLink()
        {
            try
            {
                var createNewLink = _driver.FindElement(By.LinkText("Create New"));
                createNewLink.Click();
            }
            catch(Exception e)
            {
                Assert.Fail("Could not find create link: " + e.Message);
            }
            return new CreatePage(_driver);
        }

        public DeleteFoodPage ClickDeleteFood(string foodDescription)
        {
            try
            {
                // get the food table
                var foodTable = _driver.FindElement(By.ClassName("table"));
                // get all the rows in the table
                var rowList = foodTable.FindElements(By.TagName("tr"));
                // find all the rows with the food description
                var foodRow = rowList.Where(x => x.Text.Contains(foodDescription));

                if (foodRow.Count() == 0)
                {
                    Assert.Fail("Could not find the food in the table");
                }
                else
                {
                    // get the first food row and delete it
                    var firstFoodRow = foodRow.ElementAt(0);
                    // get the delete link
                    var deleteLink = firstFoodRow.FindElement(By.LinkText("Delete"));
                    deleteLink.Click();
                }
            }
            catch(Exception e)
            {
                Assert.Fail("Could not delete food: " + e.Message);
            }
            return new DeleteFoodPage(_driver);
        }

        public NutritionPage RemoveAllFood(string foodDescription)
        {
            try
            {
                // get the food table
                var foodTable = _driver.FindElement(By.ClassName("table"));
                // get all the rows in the table
                var rowList = foodTable.FindElements(By.TagName("tr"));
                // find all the rows with the food description
                var foodRow = rowList.Where(x => x.Text.Contains(foodDescription));

                if (foodRow.Count() != 0)
                {
                    foreach(var row in foodRow)
                    {
                        var deleteLink = row.FindElement(By.LinkText("Delete"));
                        deleteLink.Click();
                        var deletePage = new DeleteFoodPage(_driver);
                        deletePage.ClickDeleteButton();
                    }
                }
                    
                    
            }
            catch (Exception e)
            {
                Assert.Fail("Could not delete exercise: " + e.Message);
            }
            
            return this;
        }

        public EditFoodPage ClickEditFoodLink(string foodDescription)
        {
            try
            {
                // get the food table
                var foodTable = _driver.FindElement(By.ClassName("table"));
                // get all the rows in the table
                var rowList = foodTable.FindElements(By.TagName("tr"));
                // find all the rows with the food description
                var foodRow = rowList.Where(x => x.Text.Contains(foodDescription));

                if (foodRow.Count() == 0)
                {
                    Assert.Fail("Could not find the food in the table");
                }
                else
                {
                    // get the first food row and delete it
                    var firstFoodRow = foodRow.ElementAt(0);
                    // get the delete link
                    var editLink = firstFoodRow.FindElement(By.LinkText("Edit"));
                    editLink.Click();
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Could not edit food: " + e.Message);
            }
            return new EditFoodPage(_driver);
        }
        #endregion

        #region Verifications
        public NutritionPage VerifyNutritionPageReached()
        {
            try
            {
                var createNewLink = _driver.FindElement(By.XPath("/html/body/div[2]/p/a"));
                Assert.AreEqual("Create New", createNewLink.Text, "could not find create new link");
            }
            catch(Exception e)
            {
                Assert.Fail("Could not find create new link and verify nutrition page reached: " + e.Message);
            }

            return this;
        }

        public NutritionPage VerifyFoodInTable(string description, int numTimes)
        {
            try
            {
                var foodTable = _driver.FindElement(By.ClassName("table"));
                var rowList = foodTable.FindElements(By.TagName("tr"));
                var numTimesFoodInTable = rowList.Where(row => row.Text.Contains(description)).Count();

                Assert.AreEqual(numTimes, numTimesFoodInTable, "The food is in the table the wrong number of times.");
            }
            catch(Exception e)
            {
                Assert.Fail("Verify food failed: " + e.Message);
            }
            return this;
        }

        public NutritionPage VerifyFoodNotInTable(string description)
        {
            try
            {
                var foodTable = _driver.FindElement(By.ClassName("table"));
                var rowList = foodTable.FindElements(By.TagName("tr"));
                var numTimesFoodInTable = rowList.Where(row => row.Text.Contains(description)).Count();

                Assert.AreEqual(0, numTimesFoodInTable, "Food found in table, should not be in table");
            }
            catch (Exception e)
            {
                Assert.Fail("Verify food not in table failed: " + e.Message);
            }
            return this;
        }

        public NutritionPage VerifyCarbs(string foodDescription, string carbs)
        {
            try
            {
                var foodTable = _driver.FindElement(By.ClassName("table"));
                var rowList = foodTable.FindElements(By.TagName("tr"));
                var foodRow = rowList.FirstOrDefault(row => row.Text.Contains(foodDescription));
                
                if (foodRow == null)
                {
                    Assert.Fail("Could not find the food row");
                }
                else
                {
                    var dataElements = foodRow.FindElements(By.TagName("td"));
                    var carbElement = dataElements[7];
                    Assert.AreEqual(carbs, carbElement.Text, "Carb value is wrong.");
                    
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Verify food failed: " + e.Message);
            }
            return this;
        }
        #endregion
    }
}