using System;
using TaskManager2.DataAccess.EFModels;
using TaskManager2.DataAccess.Models;

namespace TaskManager2.DataAccess.Converters
{
    public class ModelConverter
    {
        public static MyTaskInList Convert(Task t)
        {
            return new MyTaskInList
                {
                    Id = t.TaskId,
                    Text = t.TaskText,
                    AssignDateTime = t.AssignDateTime,
                    Sender = t.TaskSender != null ? t.TaskSender.UserFullName : string.Empty,
                    Deadline = t.Deadline,
                    IsRecipientViewed = t.IsRecipientViewed,
                    TaskPriorityId = t.PriorityId
                };
        }

    }
}