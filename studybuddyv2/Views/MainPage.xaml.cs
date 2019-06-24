using System;
using System.Collections.Generic;
using studybuddyv2.ViewModels;
using Xamarin.Forms;

namespace studybuddyv2.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
