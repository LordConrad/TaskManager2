using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.DataService.Database.DbModels
{
    [Table("UserDetails")]
    public class UserDetails
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        public string Sex { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        [ForeignKey("UserDetails")]
        public virtual AspNetUsers UserProfile { get; set; }
    }

    
}