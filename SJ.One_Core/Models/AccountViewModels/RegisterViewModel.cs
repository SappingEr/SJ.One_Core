using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введите Email")]
        [EmailAddress(ErrorMessage = "Введите корректный Email")]     
        [StringLength(50, ErrorMessage = "Длина Email не должна превышать 50 символов")]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Длина пароля должна быть от 6 до 50 символов")]
        public string Password { get; set; }

        [StringLength(20)]
        [Display(Name = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль повторно")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
