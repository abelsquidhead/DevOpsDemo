using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MercuryHealth.Web.Controllers;
using System.Web.Mvc;
using Microsoft.QualityTools.Testing.Fakes;
using System.Configuration.Fakes;
using System.Collections.Specialized;

namespace MercuryHealth.UnitTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Home")]
        public void HomeIndex()
        {
            using(ShimsContext.Create())
            {
                var fakeNameValueCollection = new NameValueCollection();
                fakeNameValueCollection.Add("Environment", "UNITTEST");

                ShimConfigurationManager.AppSettingsGet = () => fakeNameValueCollection;
                var homeController = new HomeController();
                ViewResult result = homeController.Index() as ViewResult;
                var viewName = result.ViewName;

                // checking that homecontroller.index goes to the page
                Assert.AreEqual("", viewName);

            }

        }

        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Home")]
        public void HomeAbout()
        {
            var homeController = new HomeController();
            ViewResult result = homeController.About() as ViewResult;
            var viewName = result.ViewName;

            // checking that homecontroller.index goes to the page
            Assert.AreEqual("", viewName);

        }

        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Home")]
        public void HomeContact()
        {
            var homeController = new HomeController();
            ViewResult result = homeController.Contact() as ViewResult;
            var viewName = result.ViewName;

            // checking that homecontroller.index goes to the page
            Assert.AreEqual("", viewName);

        }

        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Home")]
        public void HomeExercises()
        {
            var homeController = new HomeController();
            ViewResult result = homeController.Contact() as ViewResult;
            var viewName = result.ViewName;

            // checking that homecontroller.index goes to the page
            Assert.AreEqual("", viewName);

        }


        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Home")]
        public void HomeNutrition()
        {
            var homeController = new HomeController();
            ViewResult result = homeController.Contact() as ViewResult;
            var viewName = result.ViewName;

            // checking that homecontroller.index goes to the page
            Assert.AreEqual("", viewName);

        }

        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Home")]
        public void HomeRegister()
        {
            var homeController = new HomeController();
            ViewResult result = homeController.Contact() as ViewResult;
            var viewName = result.ViewName;

            // checking that homecontroller.index goes to the page
            Assert.AreEqual("", viewName);

        }

        [TestMethod]
        [TestCategory("Unit Test"), TestCategory("Home")]
        public void HomeLogin()
        {
            var homeController = new HomeController();
            ViewResult result = homeController.Contact() as ViewResult;
            var viewName = result.ViewName;

            // checking that homecontroller.index goes to the page
            Assert.AreEqual("", viewName);

        }

        
    }
}
