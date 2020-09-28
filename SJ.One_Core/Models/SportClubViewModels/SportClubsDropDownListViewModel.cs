using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models.SportClubViewModels
{
    public class SportClubsDropDownListViewModel
    {
        [Required(ErrorMessage = "Выберите клуб")]
        [Display(Name = "Спортивный клуб")]
        public int ClubId { get; set; }

        public IEnumerable<SelectListItem> Clubs { get; set; }
    }
}
