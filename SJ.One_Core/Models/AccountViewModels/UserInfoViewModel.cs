using System;
using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models.AccountViewModels
{
    public class UserInfoViewModel
    {    
        public string Id { get; set; }
        public byte[] Avatar { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? DOB { get; set; }

        public string UserData => $"{FirstName} {Surname} {Convert.ToDateTime(DOB):d}";

        [Display(Name = "Пол")]
        public Gender Gender { get; set; }

        [Display(Name = "Населённый пункт")]
        public string Locality { get; set; } = "Укажите населённый пункт";

        [Display(Name = "Спортивный клуб")]
        public string Club { get; set; } = "Укажите спортивный клуб";

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Номер телефона")] 
        public string PhoneNumber { get; set; } = "Не указан";

        public bool EmptyProp => string.IsNullOrWhiteSpace(FirstName)||
                       string.IsNullOrWhiteSpace(DOB.ToString())||
                       string.IsNullOrWhiteSpace(Gender.ToString());
    }
}
    