using System;
using System.Collections.Generic;
using studybuddyv2.ViewModels;
using Xamarin.Forms;

namespace studybuddyv2.Views
{
    public partial class CreateAssignmentPage : ContentPage
    {
        public CreateAssignmentPage()
        {
            InitializeComponent();
            BindingContext = new CreateAssignmentViewModel();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}
