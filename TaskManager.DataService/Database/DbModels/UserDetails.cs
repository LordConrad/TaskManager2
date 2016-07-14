using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Database.DbModels
{
    [Table("UserDetails")]
    public class UserDetails
    {
        [Key, ForeignKey("UserProfile")]
        public int UserId { get; set; }

        public string Sex { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }

        public virtual ApplicationUser UserProfile { get; set; }
    }

    
}