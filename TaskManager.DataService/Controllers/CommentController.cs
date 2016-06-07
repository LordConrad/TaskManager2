using System.Collections.Generic;
using System.Web.Http;
using TaskManager.DataService.Models;
using TaskManager.DataService.Services;
using TaskManager.DataService.Utilities;

namespace TaskManager.DataService.Controllers
{
    [CacheControl(MaxAge = 3)]
    public class CommentController : ApiController
    {
        private readonly ICommentService _commentService;

        public CommentController()
        {
            _commentService = new CommentService();
        }

        [Route("api/comment/{id:int}")]
        public IEnumerable<Comment> Get(int id)
        {
            var res = _commentService.GetTaskComments(id);
            return res;
        } 

        public bool Post(Comment comment)
        {
            return _commentService.AddComment(comment);
        }

        
    }
}
