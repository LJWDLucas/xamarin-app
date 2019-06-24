using System;
namespace studybuddyv2.Models
{
    public class Deliverable
    {
        string Id { get; set; }
        string AssignmentId { get; set; }
        string UserId { get; set; }
        string Body { get; set; }

        public Deliverable()
        {
        }
    }
}
