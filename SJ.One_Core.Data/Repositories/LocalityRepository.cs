using SJ.One_Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SJ.One_Core.Data.Repositories
{
    public class LocalityRepository : BaseRepository<Locality>, ILocalityRepository
    {
        public LocalityRepository(SJOneContext context) : base(context)
        {    
            
        }

        public async Task<List<Locality>> GetByNameRegionLocalitiesAsync(int id, string name)
        {           
            List<Locality> regionLocalities = await GetSomeAsync(l => l.RegionId == id);
            List<Locality> byNameLocalities = regionLocalities.Where(c => c.Name.ToUpper().Contains(name.ToUpper())).ToList();
            return byNameLocalities;
        }
                 
    }

    public interface ILocalityRepository : IRepository<Locality>
    {
        Task<List<Locality>> GetByNameRegionLocalitiesAsync(int id, string name);
    }
}
