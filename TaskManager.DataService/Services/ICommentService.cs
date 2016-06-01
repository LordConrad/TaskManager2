using System.Collections.Generic;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Services
{
    public interface ICommentService
    {
        bool AddComment(Comment comment);
        IEnumerable<Comment> GetTaskComments(int taskId);
    }
}