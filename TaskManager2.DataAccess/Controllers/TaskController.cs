using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TaskManager2.DataAccess.Services;
using TaskManager2.DataAccess.Utilities;

namespace TaskManager2.DataAccess.Controllers
{
    [CacheControl(MaxAge = 3)]
    public class TaskController : ApiController
    {
        private readonly ITaskService _taskService = null;

        private ITaskService TaskService => _taskService ?? new TaskService();

        public IEnumerable<Models.Task> Get()
        {
            return TaskService.GetAllTasks();
        } 
    }
}