using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models.AccountViewModels
{
    public class SportClubViewModel : BaseEntityViewModel
    {
        public string ReturnUrl { get; set; }

        [Required]
        [Display(Name = "Регион")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите регион")]
        public int ClubRegionId { get; set; }
        public IEnumerable<SelectListItem> ClubRegions { get; set; }

        [Required]
        [Display(Name = "Населённый пункт")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите населённый пункт")]
        public int ClubLocalityId { get; set; }
        public IEnumerable<SelectListItem> ClubLocalities { get; set; }


        [Required]
        [Display(Name = "Спортивный клуб")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите клуб")]
        public int ClubId { get; set; }
        public IEnumerable<SelectListItem> Clubs { get; set; }
    }
}
