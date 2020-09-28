using System.Collections.Generic;

namespace SJ.One_Core.Models
{
    public class Region : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<Locality> Localities { get; set; }
    }
}
