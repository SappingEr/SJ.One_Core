using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SJ.One_Core.Models.AccountViewModels
{
    public class UserDataViewModel
    {
        public string Id { get; set; }

        public string ReturnUrl { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Количество допустимых символов не менее 2, не более 50.")]
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите Имя.")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Количество допустимых символов не менее 2, не более 50.")]
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите Фамилию.")]
        public string Surname { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Укажите дату рождения.")]
        public DateTime DOB { get; set; }
    }
}
