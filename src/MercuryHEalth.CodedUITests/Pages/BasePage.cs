using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryHEalth.CodedUITests.Pages
{
    public class BasePage
    {
        protected BrowserWindow _browser;

        public BasePage()
        {

        }

        #region Actions
        public void Close()
        {
            _browser.Close();
        }

        public HomePage BrowseToHomePage(string homePageUrl)
        {
            _browser.NavigateToUrl(new Uri(homePageUrl));
            return new HomePage(_browser);
        }

        public NutritionPage ClickNutritionLink()
        {
            try
            {
                var nutritionLink = new HtmlHyperlink(_browser);
                nutritionLink.SearchProperties.Add(HtmlHyperlink.PropertyNames.InnerText, "Nutrition");
                nutritionLink.SearchProperties.Add(HtmlHyperlink.PropertyNames.AbsolutePath, "/FoodLogEntries");
                nutritionLink.Find();

                Mouse.Click(nutritionLink);
            }
            catch(Exception e)
            {
                Assert.Fail("Could not find nutrition link: " + e.Message);
            }

            return new NutritionPage(_browser);
        }

        public ExercisePage ClickExercisesLink()
        {
            try
            {
                var excercisesLink = new HtmlHyperlink(_browser);
                excercisesLink.SearchProperties.Add(HtmlHyperlink.PropertyNames.Href, "/Exercises");
                excercisesLink.SearchProperties.Add(HtmlHyperlink.PropertyNames.InnerText, "Excerciese");
                excercisesLink.Find();

                Mouse.Click(excercisesLink);
            }
            catch(Exception e)
            {
                Assert.Fail("Could not find excercises link: " + e.Message);
            }

            return new ExcercisePage(_browser);
        }

        public MyMetricsPage ClickMyMetricsLink()
        {
            try
            {
                var myMetricsLink = new HtmlHyperlink(_browser);
                myMetricsLink.SearchProperties.Add(HtmlHyperlink.PropertyNames.InnerText, "My Metrics");
                myMetricsLink.Find();

                Mouse.Click(myMetricsLink);
            }
            catch(Exception e)
            {
                Assert.Fail("Could not find My Metrics link: " + e.Message);
            }

            return new MyMetricsPage(_browser);
        }
        #endregion

        #region Launch Browser
        public static HomePage Launch(string homePageUrl, string browserType = "ie")
        {
            BrowserWindow.CurrentBrowser = browserType;
            var browser = BrowserWindow.Launch(homePageUrl);
            return new HomePage(browser);
        }

        #endregion
    }
}
