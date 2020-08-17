using System.ComponentModel.DataAnnotations.Schema;

namespace SJ.One_Core.Models
{
    public class EventImage : FileDetails
    {
        public int SportEventId { get; set; }
        public SportEvent SportEvent { get; set; }
    }
}
