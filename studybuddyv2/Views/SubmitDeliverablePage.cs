using System;

using Xamarin.Forms;

namespace studybuddyv2.Views
{
    public class SubmitDeliverablePage : ContentPage
    {
        public SubmitDeliverablePage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

