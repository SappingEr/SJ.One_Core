using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
