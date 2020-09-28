using System.Collections.Generic;

namespace SJ.One_Core.Models
{
    public class Locality : BaseEntity
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public List<User> LocalityUsers { get; set; }
        public List<SportEvent> LocalitySportEvents { get; set; }
        public List<SportClub> LocalitySportClubs { get; set; } = new List<SportClub>();
    }
}
