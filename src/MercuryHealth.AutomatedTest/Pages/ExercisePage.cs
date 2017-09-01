using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace MercuryHealth.AutomatedTest.Pages
{
    public class ExercisePage : BasePage
    {
        public ExercisePage(IWebDriver driver)
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

        public DeleteExercisePage ClickDeleteExercise(string exerciseDescription)
        {
            try
            {
                // get the exercise table
                var exerciseTable = _driver.FindElement(By.ClassName("table"));
                // get all the rows in the table
                var rowList = exerciseTable.FindElements(By.TagName("tr"));
                // find all the rows with the food description
                var exerciseRow = rowList.Where(x => x.Text.Contains(exerciseDescription));

                if (exerciseRow.Count() == 0)
                {
                    Assert.Fail("Could not find the exercise in the table");
                }
                else
                {
                    // get the first food row and delete it
                    var firstExerciseRow = exerciseRow.ElementAt(0);
                    // get the delete link
                    var deleteLink = firstExerciseRow.FindElement(By.LinkText("Delete"));
                    deleteLink.Click();
                }
            }
            catch(Exception e)
            {
                Assert.Fail("Could not delete exercise: " + e.Message);
            }
            return new DeleteExercisePage(_driver);
        }

        public ExercisePage RemoveAllExercises(string exerciseDescription)
        {
            try
            {
                // get the exercise table
                var exerciseTable = _driver.FindElement(By.ClassName("table"));
                // get all the rows in the table
                var rowList = exerciseTable.FindElements(By.TagName("tr"));
                // find all the rows with the food description
                var foodRow = rowList.Where(x => x.Text.Contains(exerciseDescription));

                if (foodRow.Count() == 0)
                {
                    Assert.Fail("Could not find the exercise in the table");
                }
                else
                {
                    foreach(var row in foodRow)
                    {
                        var deleteLink = row.FindElement(By.LinkText("Delete"));
                        deleteLink.Click();
                        var deletePage = new DeleteExercisePage(_driver);
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

        public EditExercisePage ClickEditExerciseLink(string exerciseDescription)
        {
            try
            {
                // get the exercise table
                var exerciseTable = _driver.FindElement(By.ClassName("table"));
                // get all the rows in the table
                var rowList = exerciseTable.FindElements(By.TagName("tr"));
                // find all the rows with the exercise description
                var exerciseRow = rowList.Where(x => x.Text.Contains(exerciseDescription));

                if (exerciseRow.Count() == 0)
                {
                    Assert.Fail("Could not find the exercise in the table");
                }
                else
                {
                    // get the first exercise row and delete it
                    var firstExerciseRow = exerciseRow.ElementAt(0);
                    // get the delete link
                    var deleteLink = firstExerciseRow.FindElement(By.LinkText("Edit"));
                    deleteLink.Click();
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Could not edit exercise: " + e.Message);
            }
            return new EditExercisePage(_driver);
        }
        #endregion

        #region Verifications
        public ExercisePage VerifyExercisePageReached()
        {
            try
            {
                var createNewLink = _driver.FindElement(By.XPath("/html/body/div[2]/p/a"));
            }
            catch(Exception e)
            {
                Assert.Fail("Could not find create new link and verify exercise page reached: " + e.Message);
            }

            return this;
        }

        public ExercisePage VerifyExerciseInTable(string description, int numTimes)
        {
            try
            {
                var exerciseTable = _driver.FindElement(By.ClassName("table"));
                var rowList = exerciseTable.FindElements(By.TagName("tr"));
                var numTimesExerciseInTable = rowList.Where(row => row.Text.Contains(description)).Count();

                Assert.AreEqual(numTimes, numTimesExerciseInTable, "The exercise is in the table the wrong number of times.");
            }
            catch(Exception e)
            {
                Assert.Fail("Verify exercise failed: " + e.Message);
            }
            return this;
        }

        public ExercisePage VerifyExerciseNotInTable(string description)
        {
            try
            {
                var exerciseTable = _driver.FindElement(By.ClassName("table"));
                var rowList = exerciseTable.FindElements(By.TagName("tr"));
                var numTimesExerciseInTable = rowList.Where(row => row.Text.Contains(description)).Count();

                Assert.AreEqual(0, numTimesExerciseInTable, "Exercise found in table, should not be in table");
            }
            catch (Exception e)
            {
                Assert.Fail("Verify exercise not in table failed: " + e.Message);
            }
            return this;
        }

        public ExercisePage VerifyCarbs(string exerciseDescription, string carbs)
        {
            try
            {
                var exerciseTable = _driver.FindElement(By.ClassName("table"));
                var rowList = exerciseTable.FindElements(By.TagName("tr"));
                var exerciseRow = rowList.FirstOrDefault(row => row.Text.Contains(exerciseDescription));
                
                if (exerciseRow == null)
                {
                    Assert.Fail("Could not find the exercise row");
                }
                else
                {
                    var dataElements = exerciseRow.FindElements(By.TagName("td"));
                    var carbElement = dataElements[7];
                    Assert.AreEqual(carbs, carbElement.Text, "Carb value is wrong.");
                    
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Verify exercise failed: " + e.Message);
            }
            return this;
        }
        #endregion
    }
}