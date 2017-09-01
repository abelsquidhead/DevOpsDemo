using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using MercuryHEalth.CodedUITests.Pages;
using System.Configuration;

namespace MercuryHEalth.CodedUITests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class MercuryHealthAppTests
    {
        private static string _homePageUrl;
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

        [TestMethod]
        [TestCategory("IETests")]
        public void BrowseToHomePageTest()
        {
            HomePage.Launch(_homePageUrl, _browserType)
                .VerifyHomePageReached();
            
        }

        [TestMethod]
        [TestCategory("IETests")]
        public void BrowseToNutritionPageTest()
        {
            HomePage.Launch(_homePageUrl, _browserType)
                .VerifyHomePageReached()
                .ClickNutritionLink()
                .VerifyNutritionPageReached();
                
        }

        [TestMethod]
        [TestCategory("IETests")]
        public void BrowseToCreateFoodLogEntryTest()
        {
            HomePage.Launch(_homePageUrl, _browserType)
                .VerifyHomePageReached()
                .ClickNutritionLink()
                .VerifyNutritionPageReached()
                .ClickCreateNewLink()
                .VerifyCreatePageReached();
        }


        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
