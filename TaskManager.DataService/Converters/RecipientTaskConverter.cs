using System;
using TaskManager.DataService.Database.DbModels;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Converters
{
    public class RecipientTaskConverter
    {
        public static RecipientTask Convert(Task t)
        {
            return new RecipientTask
            {
                Id = t.TaskId,
                Text = t.TaskText,
                AssignDateTime = t.AssignDateTime.Value,
                Deadline = t.Deadline.Value,
                SenderId = t.SenderId,
                RecipientId = t.RecipientId.Value,
                SenderName = t.TaskSender.FullName,
                CompleteDateTime = t.CompleteDate,
                AcceptCompleteDateTime = t.AcceptCpmpleteDate,
                PriorityId = t.TaskPriority != null ? t.TaskPriority.PriorityId : (int?)null,
                PriorityName = t.TaskPriority != null ? t.TaskPriority.PriorityName : null,
                IsRecipientViewed = t.IsRecipientViewed
            };
        }
        
    }
}