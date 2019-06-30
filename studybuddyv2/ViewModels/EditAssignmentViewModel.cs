using System;
using System.ComponentModel;
using studybuddyv2.Models;

namespace studybuddyv2.ViewModels
{
    public class EditAssignmentViewModel : INotifyPropertyChanged
    {
        public Assignment _assignment { get; set; }
        public EditAssignmentViewModel(Assignment assignment)
        {
            _assignment = assignment;
        }

        public int GetNumberOfDeliverables
        {
            get => _assignment.DeliveredAssignments.Count;
        }

        public string GetScoreMechanism
        {
            get
            {
                string name = "";
                switch (_assignment.ScoreMechanism)
                {
                    case 0:
                        name = "None";
                        break;
                    case 1:
                        name = "Between 1 and 5";
                        break;
                    case 2:
                        name = "Between 1 and 10";
                        break;
                    default:
                        break;
                }
                return name;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
