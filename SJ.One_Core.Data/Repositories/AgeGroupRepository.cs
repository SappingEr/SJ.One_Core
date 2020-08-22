using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Repositories
{
    public class AgeGroupRepository : BaseRepository<AgeGroup>, IAgeGroupRepository
    {
        public AgeGroupRepository(SJOneContext context) : base(context)
        {
        }
    }

    public interface IAgeGroupRepository : IRepository<AgeGroup>
    {
    }
}
