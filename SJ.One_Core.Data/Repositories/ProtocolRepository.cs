using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Repositories
{
    public class ProtocolRepository : BaseRepository<Protocol>, IProtocolRepository
    {
        public ProtocolRepository(SJOneContext context) : base(context)
        {
        }
    }

    public interface IProtocolRepository : IRepository<Protocol>
    {
    }
}
