using System;
using System.Collections.Generic;
using studybuddyv2.Models;
using studybuddyv2.ViewModels;
using Xamarin.Forms;

namespace studybuddyv2.Views
{
    public partial class SubmitDeliverablePage : ContentPage
    {
        public SubmitDeliverablePage(Assignment assignment)
        {
            InitializeComponent();
            BindingContext = new SubmitDeliverableViewModel(assignment);
        }
    }
}
