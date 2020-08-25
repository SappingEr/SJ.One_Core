using SJ.One_Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace SJ.One_Core.Data.Repositories
{
    public class LocalityRepository : BaseRepository<Locality>, ILocalityRepository
    {
        public LocalityRepository(SJOneContext context) : base(context)
        {
        }

        public List<Locality> GetByNameRegionLocalities(int id, string name) =>
            GetSome(r => r.RegionId == id).Where(l => l.Name.ToUpper().Contains(name.ToUpper())).ToList();        
    }

    public interface ILocalityRepository : IRepository<Locality>
    {
        List<Locality> GetByNameRegionLocalities(int id, string name);
    }
}
