using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Repositories
{
    public class SportEventRepository : BaseRepository<SportEvent>, ISportEventRepository
    {
        public SportEventRepository(SJOneContext context) : base(context)
        {
        }
    }

    public interface ISportEventRepository : IRepository<SportEvent>
    {
    }
}
