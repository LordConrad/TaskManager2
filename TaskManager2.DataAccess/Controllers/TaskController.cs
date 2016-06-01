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

        [HttpGet]
        [Route("api/recipientTasks")]
        public IEnumerable<RecipientTask> GetRecipientTasks()
        {
            var result = _taskService.GetRecipientTasks();
            return result;
        }

        [HttpGet]
        [Route("api/recipientTask/{id:int}")]
        public RecipientTask GetRecipientTask(int id)
        {
            return _taskService.GetRecipientTask(id);
        }

        [HttpGet]
        [Route("api/senderTasks/{senderId:int}")]
        public IEnumerable<SenderTask> GetSenderTasks(int senderId)
        {
            return _taskService.GetSenderTasks(senderId);
        }

    }
}