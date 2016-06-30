using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        public int TaskId { get; set; }
        [Required]
        [ForeignKey("TaskId")]
        virtual public Task Task { get; set; }

        [Required]
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        virtual public AspNetUsers Author { get; set; }
    }
}
