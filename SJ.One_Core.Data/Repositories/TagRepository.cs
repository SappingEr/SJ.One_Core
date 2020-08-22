using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(SJOneContext context) : base(context)
        {
        }
    }

    public interface ITagRepository : IRepository<Tag>
    {
    }
}
