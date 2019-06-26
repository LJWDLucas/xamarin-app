using System;
using System.Collections.Generic;
using studybuddyv2.ViewModels;
using Xamarin.Forms;

namespace studybuddyv2.Views
{
    public partial class ManageDeliverablePage : ContentPage
    {
        public ManageDeliverablePage()
        {
            InitializeComponent();

            BindingContext = new ManageDeliverableViewModel(Navigation);
        }

        void Handle_Back(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}
