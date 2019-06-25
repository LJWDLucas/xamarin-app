using System;
using System.Collections.Generic;
using studybuddyv2.Models;
using studybuddyv2.ViewModels;
using Xamarin.Forms;

namespace studybuddyv2.Views
{
    public partial class EditAssignmentPage : ContentPage
    {
        public EditAssignmentPage(Assignment assignment)
        {
            InitializeComponent();
            BindingContext = new EditAssignmentViewModel(assignment);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}
