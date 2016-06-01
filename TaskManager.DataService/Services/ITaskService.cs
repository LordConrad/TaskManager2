using System.Collections.Generic;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Services
{
    public interface ITaskService
    {
        IEnumerable<RecipientTask> GetRecipientTasks();
        RecipientTask GetRecipientTask(int taskId);
        IEnumerable<SenderTask> GetSenderTasks(int senderId);
    }
}
