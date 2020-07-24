using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SJ.One_Core.Models
{
    public enum Gender
    {
        [Display(Name = "Мужской")]
        Male = 1,
        [Display(Name = "Женский")]
        Female = 2
    }
}
