using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MercuryHealth.AutomatedTest.Pages;
using System.Configuration;

namespace MercuryHealth.AutomatedTest
{
    [TestClass]
    public class MercuryHealthAppTests
    {
        private static string _homePageUrl;
        private static HomePage _homePage;
        private static string _browserType;

        public MercuryHealthAppTests()
        {
            var configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

            _browserType = ConfigurationManager.AppSettings["browserType"];
            _homePageUrl = ConfigurationManager.AppSettings["appUrl"];


            System.Console.WriteLine("Url: " + _homePageUrl);
            System.Console.WriteLine("Browser type: " + _browserType);
            System.Console.WriteLine("config file: " + configFile);
        }

        #region Setup and teardown
        [ClassInitialize]

        public static void Initialize(TestContext context)
        {
            _browserType = ConfigurationManager.AppSettings["browserType"];
            _homePageUrl = ConfigurationManager.AppSettings["appUrl"];


            System.Console.WriteLine("Url: " + _homePageUrl);
            System.Console.WriteLine("Browser type: " + _browserType);

            _homePage = HomePage.Launch(_browserType);


            //
            //_homePage = HomePage.Launch(_homePageUrl, "chrome");
            //_homePage = HomePage.Launch(_homePageUrl, "IE");
            // PhantomJS is a headless WebKit scriptable witha JavaScript API.
            // uncomment for headless tests
            //_homePage = HomePage.Launch(_homePageUrl, "phantomjs");
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            // close down browser and selenium driver
            _homePage.Close();
        }
        #endregion

        #region Tests
        [TestMethod]
        [TestCategory("UITests")]
        public void BrowseToHomePageTest()
        {
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached();
        }

        [TestMethod]
        [TestCategory("UITests")]
        public void BrowseToNutritionPageTest()
        {
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()
                .ClickNutritionLink()
                .VerifyNutritionPageReached();
        }

        [TestMethod]
        [TestCategory("UITests")]
        public void BrowseToCreateFoodLogEntryTest()
        {
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()
                .ClickNutritionLink()
                .VerifyNutritionPageReached()
                .ClickCreateNewLink()
                .VerifyCreatePageReached();
        }

        [TestMethod]
        [TestCategory("UITests")]
        public void Add1stDonutTest()
        {
            // browse to home page of app
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()

                //go to nutrition page
                .ClickNutritionLink()
                .VerifyNutritionPageReached()

                // clean up and delete all donuts 
                .RemoveAllFood("Donut")

                // click create new link to add new food
                .ClickCreateNewLink()
                .VerifyCreatePageReached()

                // add donut as a food item and click the add button
                .SetDescription("Donut")
                .ClickCreateButton()
                .VerifyNutritionPageReached()
                .VerifyFoodInTable("Donut", 1)

                // clean up and delete all donuts 
                .RemoveAllFood("Donut");

        }

        [TestMethod]
        [TestCategory("UITests")]
        public void DeleteDonutTest()
        {
            // browse to home page of app
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()

                //go to nutrition page
                .ClickNutritionLink()
                .VerifyNutritionPageReached()

                // clean up and delete all donuts 
                .RemoveAllFood("Donut")

                // click create new link to add new food
                .ClickCreateNewLink()
                .VerifyCreatePageReached()

                // add donut as a food item and click the add button
                .SetDescription("Donut")
                .ClickCreateButton()
                .VerifyNutritionPageReached()
                .VerifyFoodInTable("Donut", 1)

                // delete the donut
                .ClickDeleteFood("Donut")
                .VerifyDeleteFoodPageReached()
                .ClickDeleteButton()
                .VerifyNutritionPageReached()
                .VerifyFoodNotInTable("Donut");
        }

        [TestMethod]
        [TestCategory("UITestsBroken")]
        public void Add2ndDonutTest()
        {
            // browse to home page of app
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()

                //go to nutrition page
                .ClickNutritionLink()
                .VerifyNutritionPageReached()

                // clean up and delete all donuts 
                .RemoveAllFood("Donut")

                // click create new link to add new food
                .ClickCreateNewLink()
                .VerifyCreatePageReached()

                // add donut as a food item and click the add button
                .SetDescription("Donut")
                .ClickCreateButton()
                .VerifyNutritionPageReached()
                .VerifyFoodInTable("Donut", 1)

                // add the second donut
                .ClickCreateNewLink()
                .VerifyCreatePageReached()
                .SetDescription("Donut")
                .ClickCreateButton()
                .VerifyNutritionPageReached()
                .VerifyFoodInTable("Donut", 2);

        }

        [TestMethod]
        [TestCategory("UITests")]
        public void EditDonutTest()
        {
            // browse to home page of app
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()

                //go to nutrition page
                .ClickNutritionLink()
                .VerifyNutritionPageReached()

                // clean up and delete all donuts 
                .RemoveAllFood("Donut")

                // click create new link to add new food
                .ClickCreateNewLink()
                .VerifyCreatePageReached()

                // add donut as a food item and click the add button
                .SetDescription("Donut")
                .ClickCreateButton()
                .VerifyNutritionPageReached()
                .VerifyFoodInTable("Donut", 1)

                // click on the edit for the donut
                .ClickEditFoodLink("Donut")
                .VerifyEditFoodPageReached()
                .SetCarbs("999.99")
                .ClickSaveButton()
                .VerifyNutritionPageReached()
                .VerifyCarbs("Donut", "999.99")

                // clean up and delete all donuts 
                .RemoveAllFood("Donut");

        }

        [TestMethod]
        [TestCategory("UITests")]
        public void BrowseToExercisePageTest()
        {
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()
                .ClickExercisesLink()
                .VerifyExercisePageReached();
        }

        [TestMethod]
        [TestCategory("UITests")]
        public void BrowseToCreateExerciseEntryTest()
        {
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()
                .ClickExercisesLink()
                .VerifyExercisePageReached()
                .ClickCreateNewLink()
                .VerifyCreatePageReached();
        }


        [TestMethod]
        [TestCategory("UITestsBroken")]
        public void BrowseToMyMetricsPageTest()
        {
            _homePage.BrowseToHomePage(_homePageUrl)
                .VerifyHomePageReached()
                .ClickMyMetricsLink()
                .VerifyMyMeticsPageReached();

        }
        #endregion
    }
}
