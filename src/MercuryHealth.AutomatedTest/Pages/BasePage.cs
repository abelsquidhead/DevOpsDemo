using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryHealth.AutomatedTest.Pages
{
    public class BasePage
    {
        protected IWebDriver _driver;

        protected BasePage()
        {

        }


        #region Actions
        public void Close()
        {
            _driver.Close();
            _driver.Dispose();
        }

        public HomePage BrowseToHomePage(string homePageUrl)
        {
            // browse to the home page
            _driver.Navigate().GoToUrl(homePageUrl);
            return new HomePage(_driver);
        }

        public NutritionPage ClickNutritionLink()
        {
            try
            {
                var nutritionLink = _driver.FindElement(By.LinkText("Nutrition"));
                nutritionLink.Click();
            }
            catch(Exception e)
            {
                Assert.Fail("Could not find nutrition link: " + e.Message);
            }
            return new NutritionPage(_driver);
        }

        public ExercisePage ClickExercisesLink()
        {
            try
            {
                var nutritionLink = _driver.FindElement(By.LinkText("Exercises"));
                nutritionLink.Click();
            }
            catch (Exception e)
            {
                Assert.Fail("Could not find exercises link: " + e.Message);
            }
            return new ExercisePage(_driver);
        }

        public MyMetricsPage ClickMyMetricsLink()
        {
            try
            {
                var nutritionLink = _driver.FindElement(By.LinkText("My Metrics"));
                nutritionLink.Click();
            }
            catch (Exception e)
            {
                Assert.Fail("Could not find my metrics link: " + e.Message);
            }
            return new MyMetricsPage(_driver);
        }

        #endregion


        #region Launch selenium web driver
        public static HomePage Launch(string homePageUrl, string browser = "ie")
        {
            // based on the browser passed in, created your web driver
            IWebDriver driver;
            if (browser.Equals("chrome"))
            {
                driver = new ChromeDriver();
            }
            else if (browser.Equals("phantomjs"))
            {
                driver = new PhantomJSDriver();

            }
            else
            {
                driver = new InternetExplorerDriver();
            }

            // set the window size of the browser and browse to the home page
            driver.Manage().Window.Size = new Size(1366, 768);
            driver.Navigate().GoToUrl(homePageUrl);
            return new HomePage(driver);
        }

        public static HomePage Launch(string browser = "ie")
        {
            // based on the browser passed in, created your web driver
            IWebDriver driver;
            if (browser.Equals("chrome"))
            {
                driver = new ChromeDriver();
            }
            else if (browser.Equals("phantomjs"))
            {
                driver = new PhantomJSDriver();

            }
            else
            {
                driver = new InternetExplorerDriver();
            }

            // set the window size of the browser and browse to the home page
            driver.Manage().Window.Size = new Size(1366, 768);
            return new HomePage(driver);
        }
        #endregion

    }
}
