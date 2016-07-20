using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Database.DbModels
{
    [Table("TaskEventLog")]
    public class TaskEeventLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskEventLogId { get; set; }
        [Required]
        public DateTime EventDateTime { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int TaskId { get; set; }
        public virtual Task Task { get; set; }

        [Required]
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
