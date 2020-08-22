using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(SJOneContext context) : base(context)
        {
        }
    }

    public interface ICountryRepository : IRepository<Country>
    {
    }
}
