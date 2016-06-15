using System.Collections.Generic;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Services
{
    public interface ITaskService
    {
        IEnumerable<RecipientTask> GetRecipientTasks(int recipientId);
        RecipientTask GetRecipientTask(int taskId);
        IEnumerable<SenderTask> GetSenderTasks(int senderId);
        bool CompleteTask(int id);
    }
}
