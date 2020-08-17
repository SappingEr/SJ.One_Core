using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SJ.One_Core.Models
{
    public class Region : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Locality> Localities { get; set; }
    }
}
