using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using studybuddyv2.Models;
using studybuddyv2.Services;
using Xamarin.Forms;

namespace studybuddyv2.ViewModels
{
    public class CreateAssignmentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string AssignmentName { get; set; }
        public string Body { get; set; }
        public bool SubmitSuccess { get; set; }
        public bool SubmitError { get; set; }
        public bool IsSubmitting { get; set; }

        public CreateAssignmentViewModel()
        {
            HandleSubmitCommand = new Command(async () => await CreateAssignment());
            IsSubmitting = false;
            SubmitError = false;
        }

        public List<ScoringMechanism> ItemsList { get; } = new List<ScoringMechanism>
        {
            new ScoringMechanism("None", 0),
            new ScoringMechanism("Between 1 and 5", 1),
            new ScoringMechanism("Between 1 and 10", 2)
        };

        private ScoringMechanism selectedItem;
        public ScoringMechanism SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
            }
        }

        public Command HandleSubmitCommand { get; }
        private async Task<bool> CreateAssignment()
        {
            var assignment = new Assignment
            {
                AssignmentName = AssignmentName,
                Body = Body,
                ScoreMechanism = selectedItem.Id,
                UserId = App.CurrentUser
            };
            IsSubmitting = true;
            var result = await AssignmentClient.CreateAssignment(assignment);
            IsSubmitting = false;
            if(result)
            {
                AssignmentName = "";
                Body = "";
                SubmitSuccess = true;
                return true;
            }
            SubmitError = true;
            return false;
        }
    }

    public class ScoringMechanism
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public ScoringMechanism(string name, int id)
        {
            Id = id;
            Name = name;
        }
    }
}
