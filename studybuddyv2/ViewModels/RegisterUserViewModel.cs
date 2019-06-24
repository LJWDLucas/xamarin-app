using System;
using System.ComponentModel;
using System.Threading.Tasks;
using studybuddyv2.Models;
using studybuddyv2.Services;
using Xamarin.Forms;

namespace studybuddyv2.ViewModels
{
    public class RegisterUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsLoading { get; set; }
        public string Email { get;  set; }
        public string Password { get; set; }
        public bool ShowRegistrationSuccess { get; set; }
        public bool ShowRegistrationFailure { get; set; }

        public RegisterUserViewModel()
        {
            IsLoading = false;
            HandleRegisterCommand = new Command(async () => await RegisterUser(), () => !IsLoading);
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetIsLoading(bool isLoading)
        {
            IsLoading = isLoading;
            OnPropertyChanged(nameof(IsLoading));
            HandleRegisterCommand.ChangeCanExecute();
        }

        public void SetRegistrationSuccess(bool value)
        {
            ShowRegistrationSuccess = value;
            OnPropertyChanged(nameof(ShowRegistrationSuccess));
        }

        public void SetRegistrationFailure(bool value)
        {
            ShowRegistrationFailure = value;
            OnPropertyChanged(nameof(ShowRegistrationFailure));
        }

        public Command HandleRegisterCommand { get; }
        public async Task<bool> RegisterUser()
        {
            if (ShowRegistrationSuccess == true || ShowRegistrationFailure == true)
            {
                SetRegistrationSuccess(false);
                SetRegistrationFailure(false);
            }

            SetIsLoading(true);
            var hasSucceeded = await HttpService.RegisterUser(Email, Password);
            SetIsLoading(false);
            if (hasSucceeded == true)
            {
                SetRegistrationSuccess(true);
            } else
            {
                SetRegistrationFailure(true);
            }

            return hasSucceeded;
        }

    }
}
