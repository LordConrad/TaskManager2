using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TaskManager2.DataAccess.Converters;
using TaskManager2.DataAccess.EFModels;
using Comment = TaskManager2.DataAccess.Models.Comment;

namespace TaskManager2.DataAccess.Services
{
    public class CommentService : ICommentService
    {
        public IEnumerable<Comment> GetTaskComments(int taskId)
        {
            using (var context = new TaskManagerContext())
            {
                var comments = context.Comments
                    .Include(x => x.Author)
                    .Where(x => x.TaskId == taskId).ToList();
                return ModelConverter.Convert(comments);
            }
        }

        public bool AddComment(Comment comment)
        {
            using (var context = new TaskManagerContext())
            {
                var task = context.Tasks
                    .Include(x => x.Comments)
                    .FirstOrDefault(x => x.TaskId == comment.TaskId);
                if (task == null) return false;
                try
                {
                    task.Comments.Add(new EFModels.Comment
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