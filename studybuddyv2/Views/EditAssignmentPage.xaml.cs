using System;
using System.Collections.Generic;
using studybuddyv2.ViewModels;
using Xamarin.Forms;

namespace studybuddyv2.Views
{
    public partial class EditAssignmentPage : ContentPage
    {
        public EditAssignmentPage()
        {
            InitializeComponent();
            BindingContext = new EditAssignmentViewModel();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}
