using MercuryHealthApp.Pages;
using MercuryHealthApp.Helpers;
using Xamarin.Forms;

namespace MercuryHealthApp
{
    public partial class App : Application
    {
        public App()
        {
            StyleKit.ApplyStyles(this);
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
