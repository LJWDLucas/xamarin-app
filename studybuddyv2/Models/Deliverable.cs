using System;
using Newtonsoft.Json;

namespace studybuddyv2.Models
{
    public class Deliverable
    {
        public string Id { get; set; }
        public string AssignmentId { get; set; }
        public string UserId { get; set; }
        public string Body { get; set; }

    }
}
