using System;

namespace TaskManager2.DataAccess.Models
{
    public class RecipientTask
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int SenderId { get; set; }
        // TODO: remove nullable recip ID
        public int? RecipientId { get; set; }
        public string SenderName { get; set; }
        public DateTime AssignDateTime { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? CompleteDateTime { get; set; }
        public DateTime? AcceptCompleteDateTime { get; set; }
        public int? PriorityId { get; set; }
        public string PriorityName { get; set; }
        public bool IsRecipientViewed { get; set; }
    }
}