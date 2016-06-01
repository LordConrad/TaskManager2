using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager2.DataAccess.EFModels;

namespace TaskManager2.DataAccess.Converters
{
    public class CommentConverter
    {
        public static Models.Comment Convert(Comment c)
        {
            return new Models.Comment
            {
                TaskId = c.TaskId,
                AuthorId = c.AuthorId,
                AuthorName = c.Author.UserFullName,
                CommentDate = c.CommentDate,
                CommentId = c.CommentId,
                CommentText = c.CommentText
            };
        }
    }
}