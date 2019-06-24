using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using studybuddyv2.ViewModels;
using studybuddyv2.Views;
using Xamarin.Forms;

namespace studybuddyv2
{
    [DesignTimeVisible(true)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        void Handle_Register(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new RegisterPage());
        }
    }
}
