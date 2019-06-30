using System;
using System.Collections.Generic;
using studybuddyv2.Services;
using studybuddyv2.ViewModels;
using Xamarin.Forms;

namespace studybuddyv2.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage(string id)
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(id);
        }

        void Handle_Create(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new CreateAssignmentPage());
        }

        void Handle_Find(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new FindAssignmentPage());
        }

        void Handle_Open(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new ManageDeliverablePage()));
        }

        void Handle_Logout(object sender, System.EventArgs e)
        {
            App.CurrentUser = "";
            HttpService.ResetJWT();
            Application.Current.MainPage = new LoginPage();
        }
    }
}
