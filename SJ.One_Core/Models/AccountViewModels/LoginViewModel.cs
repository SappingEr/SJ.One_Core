using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models.AccountViewModels
{
    public class LoginViewModel
    {        
        public string ReturnUrl { get; set; }

        [StringLength(50)]        
        [Required(ErrorMessage = "Введите Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        [UIHint("Boolean")]
        public bool RememberMe { get; set; }
    }
}
