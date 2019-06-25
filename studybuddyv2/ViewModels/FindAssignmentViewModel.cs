using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using studybuddyv2.Models;
using studybuddyv2.Services;
using studybuddyv2.Views;
using Xamarin.Forms;

namespace studybuddyv2.ViewModels
{
    public class FindAssignmentViewModel : INotifyPropertyChanged
    {
        public bool IsLoading { get; set; }
        public bool NoAssignments { get; set; }
        public bool HasSelected { get; set; }
        public INavigation Navigation { get; set; }
        public ObservableCollection<Assignment> List { get; set; }

        public FindAssignmentViewModel(INavigation navigation)
        {
            IsLoading = false;
            NoAssignments = false;
            HasSelected = false;
            Navigation = navigation;
            GetAssignmentsCommand = new Command(async () => await GetAssignments());
            OpenAssignmentCommand = new Command(async () => await OpenAssignment());
        }

        public Command GetAssignmentsCommand { get; }

        public Command OpenAssignmentCommand { get; }
        private Assignment selectedItem;

        public event PropertyChangedEventHandler PropertyChanged;

        public Assignment SelectedItem
        {
            get => selectedItem;
            set
            {
                HasSelected = true;
                selectedItem = value;
            }
        }

        public async Task OpenAssignment()
        {
            if (selectedItem != null)
            {
               await Navigation.PushModalAsync(new EditAssignmentPage(selectedItem));
            }
        }

        public async Task GetAssignments()
        {
            IsLoading = true;
            List<Assignment> result = await AssignmentClient.GetAssignmentsAsync();
            IsLoading = false;
            if (result.Count > 0)
            {
                NoAssignments = false;
                List = new ObservableCollection<Assignment>(result);
            } else
            {
                NoAssignments = true;
            }
        }
    }
}
