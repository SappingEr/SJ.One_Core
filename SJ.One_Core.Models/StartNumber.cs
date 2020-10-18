using System.Collections.Generic;

namespace SJ.One_Core.Models
{
    public class StartNumber : BaseEntity
    {
        public int Number { get; set; }
        public int JudgeId { get; set; }
        public User Judge { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public List<HandTiming> HandTimingsNumber { get; set; }
    }
}
