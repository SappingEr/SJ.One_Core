using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models.AccountViewModels
{
    public class DeleteUserViewModel: BaseEntityViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль!")]
        public string Password { get; set; }

    }
}
