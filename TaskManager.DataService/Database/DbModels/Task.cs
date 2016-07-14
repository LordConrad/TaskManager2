using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Database.DbModels
{
    [Table("Task")]
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string TaskText { get; set; }

        public int SenderId { get; set; }
        public virtual ApplicationUser TaskSender { get; set; }

        public int? RecipientId { get; set; }
        public virtual ApplicationUser TaskRecipient { get; set; }

        public DateTime? AssignDateTime { get; set; }
        
        public DateTime? Deadline { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public DateTime? AcceptCpmpleteDate { get; set; }

        public bool IsRecipientViewed { get; set; }

        [ForeignKey("TaskPriority")]
        public int? PriorityId { get; set; }
        
        public virtual Priority TaskPriority { get; set; }

        public string ResultComment { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<TaskEeventLog> TaskEeventLogs { get; set; }
    }
}
