using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models.AccountViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }

        [DataType(DataType.Password)]        
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль!")]
        public string Password { get; set; }

        [DataType(DataType.Password)]       
        [Display(Name = "Новый пароль")]
        [Required(ErrorMessage = "Введите новый пароль!")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Длина пароля должна быть от 6 до 50 символов")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите новый пароль")]
        [Required(ErrorMessage = "Введите новый пароль повторно!")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Длина пароля должна быть от 6 до 50 символов")]
        public string ConfirmNewPassword { get; set; }
    }
}
