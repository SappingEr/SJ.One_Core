using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models.LocalityViewModels
{
    public class LocalitiesDropDownListViewModel
    {
        [Display(Name = "Населённый пункт")]
        public int LocalityId { get; set; }

        public IEnumerable<SelectListItem> Localities { get; set; }
    }
}
