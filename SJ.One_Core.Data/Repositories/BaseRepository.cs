using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SJ.One_Core.Service.Attributes;
using SJ.One_Core.Service.Paging;
using SJ.One_Core.Service.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace SJ.One_Core.Data.Repositories
{
    public class BaseRepository<T> : IDisposable, IRepository<T>
        where T : class
    {
        protected SJOneContext Context { get; }
        private readonly DbSet<T> dbset;

        public BaseRepository() : this(new SJOneContext())
        {
        }
        public BaseRepository(SJOneContext context)
        {
            Context = context;
            dbset = Context.Set<T>();
        }

        public async Task<int> AddAsync(T entity)
        {
            dbset.Add(entity);
            return await CommitAsync();
        }

        public async Task<int> AddAsync(IList<T> entities)
        {
            dbset.AddRange(entities);
            return await CommitAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            dbset.Update(entity);
            return await CommitAsync();
        }

        public async Task<int> UpdateAsync(IList<T> entities)
        {
            dbset.UpdateRange(entities);
            return await CommitAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return await CommitAsync();
        }

        public async Task<T> GetOneAsync(int? id) => await dbset.FindAsync(id);

        public async Task<List<T>> GetAllAsync() => await dbset.ToListAsync();

        public async Task<List<T>> GetAllAsync<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending)
            => await (ascending ? dbset.OrderBy(orderBy) : dbset.OrderByDescending(orderBy)).ToListAsync();

        public async Task<T> GetOne(int? id) => await dbset.FindAsync(id);

        public async Task<List<T>> GetSomeAsync(Expression<Func<T, bool>> where) => await dbset.Where(where).ToListAsync();

        public Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int page = 1,
            int size = 4,
            bool enableTracking = false)
        {
            IQueryable<T> query = dbset;
            if (!enableTracking) query = query.AsNoTracking();
            if (where != null) query = query.Where(where);
            if (include != null) query = include(query);
            if (orderBy != null)
                return orderBy(query).PagingAsync(page, size, 0);
            return query.PagingAsync(page, size, 0);
        }

        public async Task<List<T>> FastSearchAsync(FastSearch search, bool enableTracking = false)
        {
            List<T> searchResult = new List<T>();
            if (search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.SearchString))
                {
                    IQueryable<T> query = dbset;
                    if (!enableTracking) query = query.AsNoTracking();
                    foreach (var prop in typeof(T).GetProperties())
                    {
                        var attr = prop.GetCustomAttribute<FastSearchAttribute>();
                        if (attr == null)
                        {
                            continue;
                        }
                        string crit = $"{prop.Name}.Contains(@0)";
                        query = query.Where(crit, search.SearchString).Take(10);
                        searchResult = await query.ToListAsync();
                    }
                }
            }
            return searchResult;
        }

        public List<T> ExecuteQuery(string sql) => dbset.FromSqlRaw(sql).ToList();

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
            => dbset.FromSqlRaw(sql, sqlParametersObjects).ToList();

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
