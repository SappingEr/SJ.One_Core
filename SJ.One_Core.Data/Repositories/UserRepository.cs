using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SJOneContext context) : base(context)
        {
        }
    }

    public interface IUserRepository : IRepository<User>
    {
    }
}
