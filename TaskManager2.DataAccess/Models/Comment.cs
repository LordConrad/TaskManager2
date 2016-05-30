using System;

namespace TaskManager2.DataAccess.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int TaskId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}