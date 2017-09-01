using Microsoft.VisualStudio.TestTools.UITesting;

namespace MercuryHEalth.CodedUITests.Pages
{
    internal class ExcercisePage : ExercisePage
    {
        private BrowserWindow _browser;

        public ExcercisePage(BrowserWindow _browser)
        {
            this._browser = _browser;
        }
    }
}