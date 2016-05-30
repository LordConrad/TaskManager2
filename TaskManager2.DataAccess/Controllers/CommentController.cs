using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager2.DataAccess.Models;
using TaskManager2.DataAccess.Services;
using TaskManager2.DataAccess.Utilities;

namespace TaskManager2.DataAccess.Controllers
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
            return _commentService.GetTaskComments(id);
        } 

        public bool Post(Comment comment)
        {
            return _commentService.AddComment(comment);
        }

        
    }
}
