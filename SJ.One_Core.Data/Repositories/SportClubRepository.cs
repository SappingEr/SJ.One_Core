using SJ.One_Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SJ.One_Core.Data.Repositories
{
    public class SportClubRepository : BaseRepository<SportClub>, ISportClubRepository
    {
        public SportClubRepository(SJOneContext context) : base(context)
        {
        }
        public async Task<List<SportClub>> GetByNameLocalitySportClubsAsync(int id, string name)
        {
            List<SportClub> localityClubs = await GetSomeAsync(l => l.LocalityId == id);
            List<SportClub> byNameClubs = localityClubs.Where(c => c.Name.ToUpper().Contains(name.ToUpper())).ToList();
            return byNameClubs;
        }


    }

    public interface ISportClubRepository : IRepository<SportClub>
    {
        Task<List<SportClub>> GetByNameLocalitySportClubsAsync(int id, string name);
    }
}
