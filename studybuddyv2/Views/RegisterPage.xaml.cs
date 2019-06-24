using System;
using System.Collections.Generic;
using studybuddyv2.Models;
using studybuddyv2.Services;
using studybuddyv2.ViewModels;
using Xamarin.Forms;

namespace studybuddyv2.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterUserViewModel();
        }

        void Handle_Back(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}
