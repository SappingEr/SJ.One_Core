using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Repositories
{
    public class RegionRepository : BaseRepository<Region>, IRegionRepository
    {
        public RegionRepository(SJOneContext context) : base(context)
        {
        }
    }

    public interface IRegionRepository : IRepository<Region>
    {
    }
}
