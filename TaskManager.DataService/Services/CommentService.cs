using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskManager.DataService.Converters;
using TaskManager.DataService.Database;
using Comment = TaskManager.DataService.Database.DbModels.Comment;

namespace TaskManager.DataService.Services
{
    public class CommentService : ICommentService
    {
        public IEnumerable<Models.Comment> GetTaskComments(int taskId)
        {
            using (var context = new TaskManagerContext())
            {
                return context.Comments
                    .Include(x => x.Author)
                    .Where(x => x.TaskId == taskId)
                    .Select(CommentConverter.Convert).ToList();
            }
        }

        public bool AddComment(Models.Comment comment)
        {
            using (var context = new TaskManagerContext())
            {
                var task = context.Tasks
                    .Include(x => x.Comments)
                    .FirstOrDefault(x => x.TaskId == comment.TaskId);
                if (task == null) return false;
                try
                {
                    task.Comments.Add(new Comment
                    {
                        AuthorId = comment.AuthorId,
                        CommentDate = DateTime.Now,
                        CommentText = comment.CommentText,
                    });
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
    }
}