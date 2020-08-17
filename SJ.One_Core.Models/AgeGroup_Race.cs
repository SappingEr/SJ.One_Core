namespace SJ.One_Core.Models
{
    public class AgeGroup_Race
    {
        public int? AgeGroupId { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public int? RaceId { get; set; }
        public Race Race { get; set; }
    }
}
