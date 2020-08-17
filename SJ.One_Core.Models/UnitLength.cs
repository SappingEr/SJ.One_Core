using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models
{
    public enum UnitLength : byte
    {
        [Display(Name = "Метров")]
        meters = 1,
        [Display(Name = "Километров")]
        kilometers = 2
    }
}
