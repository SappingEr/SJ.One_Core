namespace SJ.One_Core.Models
{
    public class Document : FileDetails
    {
        public int SportEventId { get; set; }
        public SportEvent SportEvent { get; set; }
    }
}
