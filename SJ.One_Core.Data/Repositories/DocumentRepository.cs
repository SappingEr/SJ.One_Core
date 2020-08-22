using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Repositories
{
    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(SJOneContext context) : base(context)
        {
        }
    }

    public interface IDocumentRepository : IRepository<Document>
    {
    }
}
