using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.DataService.Models
{
    public class UserModel
    {
        [Required]
        [DisplayName("Логин")]
        [StringLength(20, ErrorMessage = "Логин должен состоять как минимум из {2} символов"), MinLength(3)]
        public string Username { get; set; }
        [Required]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Пароль должен состоять как минимум из {2} символов"), MinLength(3)]
        public string Password { get; set; }
        [Required]
        [DisplayName("Подтверждение пароля")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}