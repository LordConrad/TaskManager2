using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TaskManager2.DataAccess.EFModels;
using TaskManager2.DataAccess.Converters;
using TaskManager2.DataAccess.Models;

namespace TaskManager2.DataAccess.Services
{
    public class TaskService : ITaskService
    {
        public IEnumerable<MyTaskInList> GetMyTasks()
        {
            using (var context = new TaskManagerContext())
            {
                var result = context.Tasks
                    .Include(x => x.TaskSender)
                    .Include(x => x.TaskRecipient)
                    .Include(x => x.TaskPriority)
                    .ToList();
                if (result.Any())
                {
                    return ModelConverter.Convert(result);
                }
                return null;
            }
        }

        public MyTask GetMyTask(int taskId)
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
                    return ModelConverter.Convert(task);
                }
                return null;
            }
        }
    }
}