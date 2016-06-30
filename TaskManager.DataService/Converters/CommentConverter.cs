using TaskManager.DataService.Models;
using Comment = TaskManager.DataService.Database.DbModels.Comment;

namespace TaskManager.DataService.Converters
{
    public class CommentConverter
    {
        public static Models.Comment Convert(Comment c)
        {
            return new Models.Comment
            {
                TaskId = c.TaskId,
                AuthorId = c.AuthorId,
                AuthorName = c.Author.FullName,
                CommentDate = c.CommentDate,
                CommentId = c.CommentId,
                CommentText = c.CommentText
            };
        }
    }
}