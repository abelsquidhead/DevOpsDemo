using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MercuryHEalth.CodedUITests.Pages
{
    public class CreatePage : BasePage
    {
        public CreatePage(BrowserWindow _browser)
        {
            this._browser = _browser;
        }

        #region Asserts
        public CreatePage VerifyCreatePageReached()
        {
            try
            {
                
            }
            catch(Exception e)
            {
                Assert.Fail("Could not find create page header: " + e.Message);
            }
            return this;
        }
        #endregion
    }
}