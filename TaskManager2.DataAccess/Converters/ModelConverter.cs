using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager2.DataAccess.EFModels;

namespace TaskManager2.DataAccess.Converters
{
    public class ModelConverter
    {
        public static Models.Task Convert(Task t)
        {
            return new Models.Task
            {
                Id = t.TaskId,
                CompleteDateTime = t.CompleteDate,
                SendDateTime = t.CreateDate,
                Text = t.TaskText,
                AssignDateTime = t.AssignDateTime,
                Recipient = t.TaskRecipient != null ? t.TaskRecipient.UserFullName : string.Empty,
                Sender = t.TaskSender != null ? t.TaskSender.UserFullName : string.Empty
                
            };
        }
    }
}