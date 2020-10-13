using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models.AccountViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль!")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите новый пароль!")]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }


        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [Required(ErrorMessage = "Введите новый пароль повторно!")]
        [Display(Name = "Подтвердите новый пароль")]
        public string ConfirmNewPassword { get; set; }
    }
}
