using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models
{
    public abstract class FileDetails : BaseEntity
    {
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(5)]
        public string Extention { get; set; }
        [MaxLength(10)]
        public int Key { get; set; }
    }
}
