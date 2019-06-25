using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace studybuddyv2.Models
{
    public class Assignment : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public int ScoreMechanism { get; set; }
        public string AssignmentName { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public List<string> DeliveredAssignments { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
