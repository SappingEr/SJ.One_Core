using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Repositories
{
    public class LocalityRepository : BaseRepository<Locality>, ILocalityRepository
    {
        public LocalityRepository(SJOneContext context) : base(context)
        {
        }
    }

    public interface ILocalityRepository : IRepository<Locality>
    {
    }
}
