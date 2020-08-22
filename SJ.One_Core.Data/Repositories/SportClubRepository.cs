using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Repositories
{
    public class SportClubRepository : BaseRepository<SportClub>, ISportClubRepository
    {
        public SportClubRepository(SJOneContext context) : base(context)
        {
        }
    }

    public interface ISportClubRepository : IRepository<SportClub>
    {
    }
}
