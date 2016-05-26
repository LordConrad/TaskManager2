using System;

namespace TaskManager2.DataAccess.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Sender { get; set; }
        public DateTime SendDateTime { get; set; }
        public string Recipient { get; set; }
        public DateTime? AssignDateTime { get; set; }
        public DateTime? CompleteDateTime { get; set; }

    }
}