using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager2.DataAccess.Models
{
    public class MyTask
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public DateTime AssignDateTime { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? CompleteDateTime { get; set; }
        public DateTime? AcceptCompleteDateTime { get; set; }
    }
}