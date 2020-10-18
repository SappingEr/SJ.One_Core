using SJ.One_Core.Models.ModelInterfaces;
using System;

namespace SJ.One_Core.Models
{
    public class AutoTiming : BaseEntity, ITiming
    {
        public int Lap { get; set; }
        public TimeSpan? LapTime { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public DateTime? TimeStamp { get; set; }
        public int JudgeId { get; set; }
        public User Judge { get; set; }
    }
}
