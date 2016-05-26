using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TaskManager2.DataAccess.EFModels;
using TaskManager2.DataAccess.Converters;
using Task = TaskManager2.DataAccess.Models.Task;

namespace TaskManager2.DataAccess.Services
{
    public class TaskService : ITaskService
    {
        public IEnumerable<Task> GetAllTasks()
        {
            using (var context = new TaskManagerContext())
            {
                return context.Tasks
                    .Include(x => x.TaskSender)
                    .Include(x => x.TaskRecipient)
                    .ToList()
                    .Select(ModelConverter.Convert);
            }
        }
    }
}