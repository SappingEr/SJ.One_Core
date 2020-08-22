using System.Collections.Generic;

namespace SJ.One_Core.Models
{
    public class AgeGroup : BaseEntity
    {
        public string Name { get; set; }
        public byte From { get; set; }
        public byte To { get; set; }
        public Gender Gender { get; set; }
        public List<AgeGroup_Race> Races { get; set; } = new List<AgeGroup_Race>();
    }
}
