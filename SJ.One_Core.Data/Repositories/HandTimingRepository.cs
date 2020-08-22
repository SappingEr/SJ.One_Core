using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Repositories
{
    public class HandTimingRepository : BaseRepository<HandTiming>, IHandTimingRepository
    {
        public HandTimingRepository(SJOneContext context) : base(context)
        {
        }
    }
    public interface IHandTimingRepository : IRepository<HandTiming>
    {
    }
}
