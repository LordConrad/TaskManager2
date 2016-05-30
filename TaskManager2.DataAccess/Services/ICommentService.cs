using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager2.DataAccess.Models;

namespace TaskManager2.DataAccess.Services
{
    public interface ICommentService
    {
        bool AddComment(Comment comment);
        IEnumerable<Comment> GetTaskComments(int taskId);
    }
}