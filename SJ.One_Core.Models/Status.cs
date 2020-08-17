using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models
{
    public enum Status
    {
        [Display(Name = "Активен")]
        Active,
        [Display(Name = "Заблокирован")]
        Blocked
    }
}
