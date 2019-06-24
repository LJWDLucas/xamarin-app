using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace studybuddyv2.Models
{
    public class Assignment : INotifyPropertyChanged
    {
        string Id { get; set; }
        int ScoreMechanism { get; }
        string AssignmentName { get; set; }
        string Body { get; set; }
        string UserId { get; set; }
        List<string> DeliveredAssignments { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
