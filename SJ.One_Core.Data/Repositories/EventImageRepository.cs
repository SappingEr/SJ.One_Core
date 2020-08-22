using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Repositories
{
    public class EventImageRepository : BaseRepository<EventImage>, IEventImageRepository
    {
        public EventImageRepository(SJOneContext context) : base(context)
        {
        }
    }

    public interface IEventImageRepository : IRepository<EventImage>
    {
    }
}
