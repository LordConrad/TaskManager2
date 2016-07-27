using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskManager.DataService.Converters;
using TaskManager.DataService.Database;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Services
{
    public interface ITaskService
    {
        IEnumerable<RecipientTask> GetRecipientTasks(int recipientId);
        RecipientTask GetRecipientTask(int taskId);
        IEnumerable<SenderTask> GetSenderTasks(int senderId);
        IEnumerable<UnassignedTask> GetUnassignedTasks(); 
        bool CompleteTask(int id);
    }

    public class TaskService : ITaskService
    {
        public IEnumerable<RecipientTask> GetRecipientTasks(int recipientId)
        {
            using (var context = new TaskManagerContext())
            {
                try
                {
                    var res = context.Tasks
                    .Include(x => x.TaskSender)
                    .Include(x => x.TaskRecipient)
                    .Include(x => x.TaskPriority)
                    .Where(x => x.RecipientId == recipientId)
                    .Select(RecipientTaskConverter.Convert).ToList();
                    return res;
                }
                catch (Exception ex)
                {
                    return null;
                }
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
                try
                {
                    var tasks = context.Tasks
                    .Include(x => x.TaskSender)
                    .Include(x => x.TaskRecipient)
                    .Include(x => x.TaskPriority)
                    .Where(x => x.SenderId == senderId)
                    .Select(SenderTaskConverter.Convert).ToList();
                    return tasks;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public IEnumerable<UnassignedTask> GetUnassignedTasks()
        {
            using (var context = new TaskManagerContext())
            {
                try
                {
                    var tasks = context.Tasks
                    .Include(x => x.TaskSender)
                    .Include(x => x.TaskPriority)
                    .Where(x => x.RecipientId == null)
                    .Select(UnassignedTaskConverter.Convert).ToList();
                    return tasks;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool CompleteTask(int id)
        {
            using (var context = new TaskManagerContext())
            {
                var task = context.Tasks.FirstOrDefault(x => x.TaskId == id);
                if (task != null)
                {
                    task.CompleteDate = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}