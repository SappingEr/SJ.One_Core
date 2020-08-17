using System.Collections.Generic;

namespace SJ.One_Core.Models
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Event_Tag> SportEvents { get; set; }
    }
}
