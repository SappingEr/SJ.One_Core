using SJ.One_Core.Models.ModelInterfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models
{
    public class HandTiming : BaseEntity, ITiming
    {
        [MaxLength(5)]
        public int Lap { get; set; }
        public TimeSpan? LapTime { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public DateTime? TimeStamp { get; set; }
        public StartNumber StartNumber { get; set; }
        public int JudgeId { get; set; }
        public User Judge { get; set; }
    }
}
