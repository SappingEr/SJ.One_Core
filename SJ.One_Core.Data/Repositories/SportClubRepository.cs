using SJ.One_Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace SJ.One_Core.Data.Repositories
{
    public class SportClubRepository : BaseRepository<SportClub>, ISportClubRepository
    {
        public SportClubRepository(SJOneContext context) : base(context)
        {
        }
        public List<SportClub> GetByNameLocalitySportClubs(int id, string name)=>
            GetSome(l => l.LocalityId == id).Where(c => c.Name.ToUpper().Contains(name.ToUpper())).ToList();

    }

    public interface ISportClubRepository : IRepository<SportClub>
    {
        List<SportClub> GetByNameLocalitySportClubs(int id, string name);
    }
}
