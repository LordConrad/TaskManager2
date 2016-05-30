using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager2.DataAccess.EFModels;
using TaskManager2.DataAccess.Models;
using Comment = TaskManager2.DataAccess.EFModels.Comment;

namespace TaskManager2.DataAccess.Converters
{
    public class ModelConverter
    {
        public static IEnumerable<MyTaskInList> Convert(IEnumerable<Task> tasks)
        {
            return tasks.Select(t => new MyTaskInList
            {
                Id = t.TaskId,
                Text = t.TaskText,
                AssignDateTime = t.AssignDateTime,
                Sender = t.TaskSender != null ? t.TaskSender.UserFullName : string.Empty,
                Deadline = t.Deadline,
                IsRecipientViewed = t.IsRecipientViewed,
                TaskPriorityId = t.PriorityId
            });
        }

        public static MyTask Convert(Task t)
        {
            return new MyTask
            {
                Id = t.TaskId,
                Text = t.TaskText,
                // todo: remove checking value
                AssignDateTime = t.AssignDateTime.HasValue ? t.AssignDateTime.Value : new DateTime(),
                Deadline = t.Deadline.HasValue ? t.Deadline.Value : new DateTime(),
                SenderId = t.SenderId,
                SenderName = t.TaskSender.UserFullName,
                CompleteDateTime = t.CompleteDate,
                AcceptCompleteDateTime = t.AcceptCpmpleteDate,
            };
        }


        public static IEnumerable<Models.Comment> Convert(ICollection<Comment> comments)
        {
            return comments.Select(c => new Models.Comment
            {
                TaskId = c.TaskId,
                AuthorId = c.AuthorId,
                AuthorName = c.Author.UserFullName,
                CommentDate = c.CommentDate,
                CommentId = c.CommentId,
                CommentText = c.CommentText
            });
        }

    }
}