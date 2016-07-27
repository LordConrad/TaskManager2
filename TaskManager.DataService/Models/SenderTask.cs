using System;

namespace TaskManager.DataService.Models
{
    public class SenderTask
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string RecipientName { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? AssignDateTime { get; set; }
        public DateTime? CompleteDateTime { get; set; }
        public DateTime? Deadline { get; set; }
    }
}