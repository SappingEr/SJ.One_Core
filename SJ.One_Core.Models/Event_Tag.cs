namespace SJ.One_Core.Models
{
    public class Event_Tag
    {
        public int EventId { get; set; }
        public Tag Tag { get; set; }
        public int? TagId { get; set; }
        public SportEvent SportEvent { get; set; }
    }
}
