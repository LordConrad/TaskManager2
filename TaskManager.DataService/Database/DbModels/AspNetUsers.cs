using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskManager.DataService.Database.DbModels
{
    [Table("AspNetUsers")]
    public class AspNetUsers
    {
        [Key, ForeignKey("UserDetails")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        [Required]
        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public bool PhoneNumberConfirmed { get; set; }
        [Required]
        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }
        [Required]
        public bool LockoutEnabled { get; set; }
        [Required]
        public int AccessFailedCount { get; set; }
        [Required]
        public string UserName { get; set; }

        public UserDetails UserDetails { get; set; }
        [ForeignKey("AuthorId")]
        public virtual ICollection<Comment> Comments { get; set; }
        [ForeignKey("SenderId")]
        public virtual ICollection<Task> SendedTasks { get; set; }
        [ForeignKey("RecipientId")]
        public virtual ICollection<Task> RecipTasks { get; set; }
        [ForeignKey("LogUser")]
        public virtual ICollection<TaskEeventLog> Logs { get; set; }
    }
}