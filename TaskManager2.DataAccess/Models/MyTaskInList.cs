using System;
using System.Collections;

namespace TaskManager2.DataAccess.Models
{
    public class MyTaskInList
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Sender { get; set; }
        public DateTime? AssignDateTime { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsRecipientViewed { get; set; }
        public int? TaskPriorityId { get; set; }
    }
}