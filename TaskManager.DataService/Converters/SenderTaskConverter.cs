using TaskManager.DataService.Database.DbModels;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Converters
{
    public class SenderTaskConverter
    {
        public static SenderTask Convert(Task t)
        {
            return new SenderTask
            {
                Id = t.TaskId,
                Text = t.TaskText,
                CompleteDateTime = t.CompleteDate,
                AssignDateTime = t.AssignDateTime,
                Deadline = t.Deadline,
                CreateDateTime = t.CreateDate,
                RecipientName = t.TaskRecipient != null ? t.TaskRecipient.FullName : ""
            };
        }
    }
}