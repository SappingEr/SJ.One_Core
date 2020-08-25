using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SJ.One_Core.Models.AccountViewModels
{
    public class LocalityViewModel
    {
        public string Id { get; set; }

        public string ReturnUrl { get; set; }

        [Required(ErrorMessage = "Выберите регион.")]
        [Display(Name = "Регион")]
        public int RegionId { get; set; }
        public IEnumerable<SelectListItem> Regions { get; set; }

        [Required(ErrorMessage = "Выберите населённый пункт.")]
        [Display(Name = "Населённый пункт")]
        public int LocalityId { get; set; }
        public IEnumerable<SelectListItem> Localities { get; set; }

        public bool AddClub { get; set; }

        [Display(Name = "Я состою в спортивном клубе")]
        public bool Club { get; set; }
    }
}
