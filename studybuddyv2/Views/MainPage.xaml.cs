using System;
using System.Collections.Generic;
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
    }
}
