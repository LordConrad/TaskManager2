using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using TaskManager2.DataAccess.EFModels;
using TaskManager2.DataAccess.Converters;
using TaskManager2.DataAccess.Models;

namespace TaskManager2.DataAccess.Services
{
    public class TaskService : ITaskService
    {
        public IEnumerable<RecipientTask> GetRecipientTasks()
        {
            using (var context = new TaskManagerContext())
            {
                return context.Tasks
                    .Include(x => x.TaskSender)
                    .Include(x => x.TaskRecipient)
                    .Include(x => x.TaskPriority)
                    .Select(RecipientTaskConverter.Convert);
            }
        }

        public RecipientTask GetRecipientTask(int taskId)
        {
            using (var context = new TaskManagerContext())
            {
                var task = context.Tasks
                    .Include(x => x.TaskSender)
                    .Include(x => x.TaskRecipient)
                    .Include(x => x.TaskPriority)
                    .FirstOrDefault(x => x.TaskId == taskId);
                if (task != null)
                {
                    return RecipientTaskConverter.Convert(task);
                }
                return null;
            }
        }

        public IEnumerable<SenderTask> GetSenderTasks(int senderId)
        {
            using (var context = new TaskManagerContext())
            {
                return context.Tasks
                    .Include(x => x.TaskSender)
                    .Include(x => x.TaskRecipient)
                    .Include(x => x.TaskPriority)
                    .Where(x => x.SenderId == senderId)
                    .Select(SenderTaskConverter.Convert);

            }
        }
    }
}