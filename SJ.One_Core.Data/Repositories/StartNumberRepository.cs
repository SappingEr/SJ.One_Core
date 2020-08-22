using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Repositories
{
    public class StartNumberRepository : BaseRepository<StartNumber>, IStartNumberRepository
    {
        public StartNumberRepository(SJOneContext context) : base(context)
        {
        }
    }

    public interface IStartNumberRepository : IRepository<StartNumber>
    {
    }
}
