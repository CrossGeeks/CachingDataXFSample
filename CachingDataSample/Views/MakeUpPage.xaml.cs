using System;
using System.Collections.Generic;
using CachingDataSample.ViewModels;
using Xamarin.Forms;

namespace CachingDataSample.Views
{
    public partial class MakeUpPage : ContentPage
    {
        public MakeUpPage()
        {
            InitializeComponent();
            BindingContext = new MakeUpPageViewModel();
        }
    }
}
