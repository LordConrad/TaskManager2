using System.Collections.Generic;
using System.Web.Http;
using TaskManager2.DataAccess.Models;
using TaskManager2.DataAccess.Services;
using TaskManager2.DataAccess.Utilities;

namespace TaskManager2.DataAccess.Controllers
{
    [CacheControl(MaxAge = 3)]
    public class TaskController : ApiController
    {
        private readonly ITaskService _taskService;

        public TaskController()
        {
            _taskService = new TaskService();
        }

        [Route("api/task")]
        public IEnumerable<MyTaskInList> Get()
        {
            var result = _taskService.GetMyTasks();
            return result;
        }

        [Route("api/task/{id:int}")]
        public MyTask Get(int id)
        {
            return _taskService.GetMyTask(id);
        }

    }
}