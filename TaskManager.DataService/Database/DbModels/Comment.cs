using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Database.DbModels
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string CommentText { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }

        public int TaskId { get; set; }
        public virtual Task Task { get; set; }

        public int AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}
