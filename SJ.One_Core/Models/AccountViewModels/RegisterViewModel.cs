using System;
using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [StringLength(50)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введите Email")]
        public string Email { get; set; }        
                
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Длина пароля должна быть от 6 до 20 символов")]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        [StringLength(20)]
        [Display(Name = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль повторно")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
