using System.Collections.Generic;

namespace SJ.One_Core.Models
{
    public class Locality : BaseEntity
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public ICollection<User> LocalityUsers { get; set; }
        public ICollection<SportEvent> LocalitySportEvents { get; set; }
        public ICollection<SportClub> LocalitySportClubs { get; set; }
    }
}
