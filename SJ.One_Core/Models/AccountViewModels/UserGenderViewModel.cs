﻿using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models.AccountViewModels
{
    public class UserGenderViewModel: BaseEntityViewModel
    {
        public string ReturnUrl { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Выберите пол из выпадающего списка")]
        public Gender Gender { get; set; }
    }
}
