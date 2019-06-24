using System;
using System.ComponentModel;
using System.Threading.Tasks;
using studybuddyv2.Models;
using studybuddyv2.Services;
using studybuddyv2.Views;
using Xamarin.Forms;

namespace studybuddyv2.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ShowError { get; set; }
        public string ErrorMessage { set; get; }
        public User user;

        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {
            HandleOnLoginCommand = new Command(async () => await LoginUser());
            ShowError = false;
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetErrorMessage(string errorMessage, bool showError)
        {
            if (showError)
            {
                ErrorMessage = errorMessage;
                ShowError = true;
            }
            else
            {
                ShowError = false;
                ErrorMessage = "";
            }
            OnPropertyChanged(nameof(ErrorMessage));
            OnPropertyChanged(nameof(ShowError));
        }

        public Command HandleOnLoginCommand { get; }
        public async Task<bool> LoginUser()
        {
            if (Email == null || Password == null)
            {
                SetErrorMessage("Missing email or password.", true);
                return false;
            }

            var result = await HttpService.LoginUser(Email, Password);

            if (result != "")
            {
                SetErrorMessage("", false);
                Application.Current.MainPage = new MainPage(result);
            }
            else
            {
                SetErrorMessage("Login failed.", true);
            }
            return true;
        }
    }
}
