using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models
{
    public enum Kind : byte
    {
        [Display(Name = "Бег")]
        Run = 1,
        [Display(Name = "Велосипед")]
        Bicycle,
        [Display(Name = "Плавание")]
        Swim,
        [Display(Name = "Обратный отсчёт")]
        Countdown
    }
}
