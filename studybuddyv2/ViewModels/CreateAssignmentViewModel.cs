using System;
using System.ComponentModel;

namespace studybuddyv2.ViewModels
{
    public class CreateAssignmentViewModel : INotifyPropertyChanged
    {
        public CreateAssignmentViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
