using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SJ.One_Core.Models.AccountViewModels
{
    public class UserDataViewModel: IValidatableObject
    {
        private readonly TextInfo textInfo = new CultureInfo("ru-RU").TextInfo;
        private string firstName;
        private string surname;

        public string Id { get; set; }

        public string ReturnUrl { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Количество допустимых символов не менее 2, не более 50")]
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите Имя")]
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = textInfo.ToTitleCase(value);
            }
        }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Количество допустимых символов не менее 2, не более 50")]
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите Фамилию")]
        public string Surname
        {
            get => surname;
            set
            {
                surname = textInfo.ToTitleCase(value);
            }
        }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Укажите дату рождения")]
        public DateTime DOB { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int maxAge = 90;
            int currentYear = DateTime.Now.Year;
            if (DOB.Year > currentYear || DOB.Year < (currentYear - maxAge))
            {
                yield return new ValidationResult("Укажите правильную дату рождения",new[] { nameof(DOB) });
            }
        }
    }
}
