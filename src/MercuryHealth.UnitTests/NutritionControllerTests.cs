using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MercuryHealth.Web.Controllers;
using System.Web.Mvc;
using MercuryHealth.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.QualityTools.Testing.Fakes;
using MercuryHealth.Web.Models.Fakes;
using System.Web.Mvc.Fakes;
using Microsoft.ApplicationInsights;

namespace MercuryHealth.UnitTest
{
    [TestClass]
    public class NutritionControllerTests
    {
        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Nutrition")]

        public void HomeMyMetrics()
        {
            var homeController = new HomeController();
            ViewResult result = homeController.Contact() as ViewResult;
            var viewName = result.ViewName;

            // checking that homecontroller.index goes to the page
            Assert.AreEqual("", viewName);

        }

        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Nutrition")]

        public void DisplayFoodLogEntryDetailsTest()
        {

            var foodLogRepoMock = new StubIFoodLogEntryRepository
            {
                GetNullableOfInt32 = (id) => new FoodLogEntry
                {
                    Id = (int)id,
                    Description = "Donut"
                }
            };

            var controller = new FoodLogEntriesController(foodLogRepoMock);
            var result = controller.Details(32) as ViewResult;
            var viewModel = result.Model as FoodLogEntry;

            Assert.AreEqual("Donut", viewModel.Description);


        }
        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Nutrition")]
        public void DisplayFoodLogEntryWhenNullDetailsTest()
        {
            var foodLogRepoMock = new StubIFoodLogEntryRepository
            {
                GetNullableOfInt32 = (id) => null
            };

            var controller = new FoodLogEntriesController(foodLogRepoMock);
            var result = controller.Details(32) as HttpNotFoundResult;

            // making sure not found happens when food log repo returns back null
            Assert.AreEqual(404, result.StatusCode);


        }

        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Nutrition")]
        public void BrowseToFoodLogEntryIndex()
        {
            var foodLogEntryList = new List<FoodLogEntry>() {
                new FoodLogEntry
                {
                    Id = 12,
                    Description = "Donut"
                },
                new FoodLogEntry
                {
                    Id = 13,
                    Description = "Apple"
                }

            };

            ///repository.GetAll().ToList()
            var foodLogRepoMock = new StubIFoodLogEntryRepository
            {
                GetAll = () => foodLogEntryList.AsQueryable()
            };

            var controller = new FoodLogEntriesController(foodLogRepoMock);
            var viewResult = controller.Index() as ViewResult;
            var vm = viewResult.Model as List<FoodLogEntry>;

            // assert the view model returned is the list i just created
            Assert.AreEqual(2, vm.Count(), "View model should have 2 food items");
            Assert.AreEqual(12, vm.ElementAt(0).Id, "First element is wrong");
            Assert.AreEqual(13, vm.ElementAt(1).Id, "Second element is worng");

        }

        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Nutrition")]
        public void BrowseToCreatePageTest()
        {
            var controller = new FoodLogEntriesController(new StubIFoodLogEntryRepository());
            var viewResult = controller.Create() as ViewResult;
            var viewModel = viewResult.Model as FoodLogEntry;

            // make sure model is correct
            Assert.AreEqual(1, viewModel.Quantity);
            Assert.AreEqual("Apple", viewModel.Description);
            Assert.AreEqual(Convert.ToDateTime("8/25/2105"), viewModel.MealTime);
            Assert.AreEqual(116, viewModel.Calories);
            Assert.AreEqual("fruit, snack", viewModel.Tags);
            Assert.AreEqual(Convert.ToDecimal("0.6"), viewModel.ProteinInGrams);
            Assert.AreEqual(Convert.ToDecimal("0.4"), viewModel.FatInGrams);
            Assert.AreEqual(Convert.ToDecimal("38.8"), viewModel.CarbohydratesInGrams);
            Assert.AreEqual(Convert.ToDecimal("2.0"), viewModel.SodiumInGrams);
        }

        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Nutrition")]
        public void SaveNewFoodLogEntryTest()
        {
            FoodLogEntry savedFood = null;
            bool createCalled = false;
            var fakeRepo = new StubIFoodLogEntryRepository()
            {
                CreateFoodLogEntry = (food) =>
                {
                    savedFood = food;
                    createCalled = true;
                }
            };

            var fakeFoodEntry = new FoodLogEntry
            {
                Id = 12
            };
            var controller = new FoodLogEntriesController(fakeRepo);
            
            var viewResult = controller.Create(fakeFoodEntry) as RedirectToRouteResult;
            var redirectPage = viewResult.RouteValues["action"] as string;

            // assert that my create was called in my repo and that the save
            // object is correct
            Assert.IsTrue(createCalled);
            Assert.AreEqual(fakeFoodEntry, savedFood);
            Assert.AreEqual("Index", redirectPage);


        }

        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Nutrition")]
        public void SaveNewFoodLogEntryBadModelStateTest()
        {
            using(ShimsContext.Create())
            {
                ShimModelStateDictionary.AllInstances.IsValidGet = (self) => false;

                var foodLogEntry = new FoodLogEntry
                {
                    Id = 10
                };
                var controller = new FoodLogEntriesController(new StubIFoodLogEntryRepository());
                var viewResult = controller.Create(foodLogEntry) as ViewResult;
                var viewModel = viewResult.Model as FoodLogEntry;

                Assert.AreEqual("", viewResult.ViewName);
                Assert.AreEqual(foodLogEntry, viewModel);
            }
        }
    }
}
