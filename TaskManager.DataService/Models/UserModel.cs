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
        [Required(ErrorMessage = "Введите логин")]
        [DisplayName("Логин")]
        [MinLength(3, ErrorMessage = "Логин должен состоять как минимум из {1} символов")]
        [MaxLength(20, ErrorMessage = "Максимальная длина логина {1} символов")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Введите фамилию и инициалы")]
        [DisplayName("Ф.И.О.")]
        [MinLength(3, ErrorMessage = "Введите фамилию и инициалы (пример: Иванов И.И.)")]
        [MaxLength(40, ErrorMessage = "Введите фамилию и инициалы (пример: Иванов И.И.)")]
        [RegularExpression(@"^([А-ЯЁ][а-яё]+\s[А-ЯЁ]\.[А-ЯЁ]\.)$", ErrorMessage = "Неверный формат Ф.И.О. (пример: Иванов И.И.)")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Пароль должен состоять как минимум из {1} символов")]
        [MaxLength(20, ErrorMessage = "Максимальная длина пароля {1} символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите ввод пароля")]
        [DisplayName("Подтверждение пароля")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}