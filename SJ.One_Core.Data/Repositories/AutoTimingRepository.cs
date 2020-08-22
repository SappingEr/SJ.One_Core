using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Repositories
{
    public class AutoTimingRepository : BaseRepository<AutoTiming>, IAutoTimingRepository
    {
        public AutoTimingRepository(SJOneContext context) : base(context)
        {
        }
    }
    public interface IAutoTimingRepository : IRepository<AutoTiming>
    {
    }
}
