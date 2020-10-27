using Microsoft.EntityFrameworkCore.Query;
using SJ.One_Core.Service.Paging;
using SJ.One_Core.Service.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SJ.One_Core.Data.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        Task<int> AddAsync(T entity);
        Task<int> AddAsync(IList<T> entities);
        Task<int> UpdateAsync(T entity);
        Task<int> UpdateAsync(IList<T> entities);
        Task<int> DeleteAsync(T entity);
        Task<T> GetOneAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetSomeAsync(Expression<Func<T, bool>> where);
        Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int index = 0, int size = 4, bool enableTracking = true);
        List<T> FastSearch(FastSearch search);
        List<T> ExecuteQuery(string sql);
        List<T> ExecuteQuery(string sql, object[] sqlParametersObjects);
    }
}
