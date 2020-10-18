using System.ComponentModel.DataAnnotations.Schema;

namespace SJ.One_Core.Models
{
    public class Protocol : FileDetails
    {
        public virtual byte[] Content { get; set; }
        public int JudgeId { get; set; }
        public virtual User Judge { get; set; }
    }
}
