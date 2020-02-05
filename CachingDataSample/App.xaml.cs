using System;
using CachingDataSample.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CachingDataSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MakeUpPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
