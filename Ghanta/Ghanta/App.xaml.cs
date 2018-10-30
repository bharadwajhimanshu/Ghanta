using Ghanta.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Ghanta
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new HomeTabbedPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=2d69a5a6-da80-4f20-a61e-7ec05fa14cea;" +
                  "uwp=c3897173-dcc3-4a33-aa57-58b7d5b3fb70;" +
                  "ios=4920d0e5-e98a-4b07-a2a7-49d30ce88e7b",
                  typeof(Analytics), typeof(Crashes));
            Analytics.TrackEvent("Application Launched");
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
