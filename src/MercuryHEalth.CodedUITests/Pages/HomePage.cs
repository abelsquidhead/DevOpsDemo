using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MercuryHEalth.CodedUITests.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(BrowserWindow browser)
        {
            _browser = browser;
        }

        #region Verifications
        public HomePage VerifyHomePageReached()
        {
            try
            {
                var homePageTitleElement = new HtmlSpan(_browser);
                homePageTitleElement.SearchProperties.Add(HtmlSpan.PropertyNames.Id, "HomePageTitle");
                homePageTitleElement.Find();
            }
            catch(Exception e)
            {
                Assert.Fail("Home page was not reached, could not find home page title: " + e.Message);
            }

            return this;
        }
        #endregion
    }
}