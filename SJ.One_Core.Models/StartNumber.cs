using System.Collections.Generic;

namespace SJ.One_Core.Models
{
    public class StartNumber : BaseEntity
    {
        public int Number { get; set; }
        public string JudgeId { get; set; }
        public User Judge { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public ICollection<HandTiming> HandTimingsNumber { get; set; }
    }
}
