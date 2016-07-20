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
        [Display(Name = "Пол")]
        public string Sex { get; set; }
        [Display(Name = "Должность")]
        public string Position { get; set; }
        [Display(Name = "Кабинет")]
        public string Location { get; set; }
        [Display(Name = "Рабочий телефон")]
        public string WorkPhoneNumber { get; set; }
        [Display(Name = "Мобильный телефон")]
        public string CellPhoneNumber { get; set; }

        public virtual ApplicationUser UserProfile { get; set; }
    }

    
}