using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models
{
    public class Race : BaseEntity
    {
        public string Name { get; set; }
        public int StartNumberCount { get; set; }
        public string Distance { get; set; }
        public UnitLength UnitLength { get; set; }
        public Kind Kind { get; set; }
        public int LapCount { get; set; }
        public int CountdownTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime? StartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime? FinishTime { get; set; }
        public string MainJudgeRaceId { get; set; }
        public User MainJudgeRace { get; set; }
        public bool AgeFromEvent { get; set; }
        public List<AgeGroup_Race> AgeGroups { get; set; }
        public List<StartNumber> StartNumbersRace { get; set; } 
        public List<User_Race> RaceJudges { get; set; } 
        public int SportEventId { get; set; }
        public SportEvent SportEvent { get; set; }
    }
}
