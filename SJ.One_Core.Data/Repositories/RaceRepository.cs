using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Repositories
{
    public class RaceRepository : BaseRepository<Race>, IRaceRepository
    {
        public RaceRepository(SJOneContext context) : base(context)
        {
        }
    }

    public interface IRaceRepository : IRepository<Race>
    {
    }
}
