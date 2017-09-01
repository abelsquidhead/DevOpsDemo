using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MercuryHEalth.CodedUITests.Pages
{
    public class NutritionPage : BasePage
    {
        public NutritionPage(BrowserWindow _browser)
        {
            this._browser = _browser;
        }

        #region Asserts
        public NutritionPage VerifyNutritionPageReached()
        {
            try
            {
                var createNewLink = new HtmlHyperlink(_browser);
                createNewLink.SearchProperties.Add(HtmlHyperlink.PropertyNames.InnerText, "CreateNew");
                createNewLink.SearchProperties.Add(HtmlHyperlink.PropertyNames.AbsolutePath, "/FoodLogEntries/Create");
                createNewLink.Find();
            }
            catch(Exception e)
            {
                Assert.Fail("Could not find create new link and verify nutrition page reached: " + e.Message);
            }
            return this;
        }

        public CreatePage ClickCreateNewLink()
        {
            try
            {
                var createNewLink = new HtmlHyperlink(_browser);
                createNewLink.SearchProperties.Add(HtmlHyperlink.PropertyNames.InnerText, "CreateNew");
                createNewLink.SearchProperties.Add(HtmlHyperlink.PropertyNames.AbsolutePath, "/FoodLogEntries/Create");
                createNewLink.Find();

                Mouse.Click(createNewLink);
            }
            catch (Exception e)
            {
                Assert.Fail("Could not find create new link and verify nutrition page reached: " + e.Message);
            }
            return new CreatePage(_browser);
        }
        #endregion
    }
}