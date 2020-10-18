using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models
{
    public enum Status
    {
        [Display(Name = "Активный")]
        Active,
        [Display(Name = "Заблокирован")]
        Blocked
    }
}
