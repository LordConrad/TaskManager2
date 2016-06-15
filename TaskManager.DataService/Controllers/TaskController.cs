using System.Collections.Generic;
using System.Web.Http;
using TaskManager.DataService.Models;
using TaskManager.DataService.Services;
using TaskManager.DataService.Utilities;

namespace TaskManager.DataService.Controllers
{
    [Authorize]
    [CacheControl(MaxAge = 3)]
    public class TaskController : ApiController
    {
        private readonly ITaskService _taskService;

        public TaskController()
        {
            _taskService = new TaskService();
        }

        [HttpGet]
        [Authorize(Roles = "Recipient")]
        [Route("api/recipientTasks/{id:int}")]
        public IEnumerable<RecipientTask> GetRecipientTasks(int id)
        {

            var result = _taskService.GetRecipientTasks(id);
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

        [HttpGet]
        [Authorize(Roles = "Recipient")]
        [Route("api/completeTask/{id:int}")]
        public IHttpActionResult CompleteTask(int id)
        {
            if (_taskService.CompleteTask(id))
            {
                return Ok();
            }
            return InternalServerError();
        }

    }
}