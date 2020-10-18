using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SJ.One_Core.Models.AccountViewModels
{
    public class LocalityViewModel: BaseEntityViewModel
    {
        public string ReturnUrl { get; set; }

        [Required]
        [Display(Name = "Регион")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите регион")]
        public int RegionId { get; set; }
        public IEnumerable<SelectListItem> Regions { get; set; }

        [Required]
        [Display(Name = "Населённый пункт")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите населённый пункт")]
        public int LocalityId { get; set; }
        public IEnumerable<SelectListItem> Localities { get; set; }

        public bool AddClub { get; set; }

        [Display(Name = "Я состою в спортивном клубе")]
        public bool Club { get; set; }
    }
}
