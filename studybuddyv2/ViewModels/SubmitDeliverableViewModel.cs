using System;
using System.ComponentModel;
using System.Threading.Tasks;
using studybuddyv2.Models;
using studybuddyv2.Services;
using Xamarin.Forms;

namespace studybuddyv2.ViewModels
{
    public class SubmitDeliverableViewModel : INotifyPropertyChanged
    {
        public Assignment Assignment { get; set; }
        public string Body { get; set; }
        public bool Success { get; set; } = false;
        public bool Failure { get; set; } = false;
        public bool IsSubmitting { get; set; } = false;

        public SubmitDeliverableViewModel(Assignment assignment)
        {
            Assignment = assignment;
            SubmitDeliverableCommand = new Command(async () => await SubmitDeliverable()); 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command SubmitDeliverableCommand { get; }

        private async Task SubmitDeliverable()
        {
            Success = false;
            Failure = false;
            IsSubmitting = true;
            Deliverable deliverable = new Deliverable
            {
                AssignmentId = Assignment.Id,
                UserId = App.CurrentUser,
                Body = Body
            };
            var result = await DeliverableClient.CreateDeliverable(deliverable);
            IsSubmitting = false;
            if (result)
            {
                Success = true;
            } else
            {
                Failure = true;
            }
        }
    }
}
