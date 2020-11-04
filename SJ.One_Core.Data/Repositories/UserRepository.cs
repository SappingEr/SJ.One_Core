using Microsoft.EntityFrameworkCore.Query;
using SJ.One_Core.Models;
using SJ.One_Core.Service.Filters;
using SJ.One_Core.Service.Filters.ModelFilters;
using System.Linq;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SJ.One_Core.Service.Paging;

namespace SJ.One_Core.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SJOneContext context) : base(context)
        {
        }

        IQueryable<User> SetupFilter(UserFilter userFilter, IQueryable<User> query)
        {
            if (userFilter != null)
            {
                if (!string.IsNullOrEmpty(userFilter.FirstName))
                {
                    query = query.Where(n => n.FirstName.Contains(userFilter.FirstName));
                }
                if (!string.IsNullOrEmpty(userFilter.Surname))
                {
                    query = query.Where(s => s.Surname.Contains(userFilter.Surname));
                }
                if (!string.IsNullOrEmpty(userFilter.Email))
                {
                    query = query.Where(e => e.Email.Contains(userFilter.Email));
                }
                if (!string.IsNullOrEmpty(userFilter.DOB))
                {
                    query = query.Where(d => d.DOB.HasValue.ToString().Contains(userFilter.DOB));
                }
                if (userFilter.DOBRange != null)
                {
                    if (userFilter.DOBRange.From != null && userFilter.DOBRange.To != null)
                    {
                        query = query.Where(d => d.DOB >= userFilter.DOBRange.From && d.DOB <= userFilter.DOBRange.To);
                    }
                }

            }
            return query;
        }

        IQueryable<User> SetupFetchOptions(FetchOptions fetchOptions, IQueryable<User> query)
        {
            if (fetchOptions.SortDirection == SortDirection.Ascending)
            {
                query = query.OrderBy(fetchOptions.SortExpression);
            }
            else if (fetchOptions.SortDirection == SortDirection.Descending)
            {
                query = query.OrderBy($"{fetchOptions.SortExpression} desc");
            }
            return query;
        }

        public async Task<List<User>> Find(UserFilter userFilter, FetchOptions fetchOptions, Func<IQueryable<User>,
            IIncludableQueryable<User, object>> include = null, bool enableTracking = false)
        {
            var query = Context.Users.AsQueryable();
            if (!enableTracking) query = query.AsNoTracking();
            query = SetupFilter(userFilter, query);
            if (include != null) query = include(query);
            if (fetchOptions.SortExpression != null)
            {
                query = SetupFetchOptions(fetchOptions, query);
            }
            List<User> users = await query.ToListAsync();
            return users;
        }

        public async Task<IPaginate<User>> Find(UserFilter userFilter, FetchOptions fetchOptions,
            Func<IQueryable<User>, IIncludableQueryable<User, object>> include = null,
            int page = 1,
            int size = 4,
            bool enableTracking = false)
        {
            var query = Context.Users.AsQueryable();
            if (!enableTracking) query = query.AsNoTracking();
            query = SetupFilter(userFilter, query);
            if (include != null) query = include(query);
            if (fetchOptions.SortExpression != null)
            {
                query = SetupFetchOptions(fetchOptions, query);
            }
            return await query.PagingAsync(page, size, 0);
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> Find(UserFilter userFilter, FetchOptions fetchOptions, Func<IQueryable<User>,
            IIncludableQueryable<User, object>> include = null, bool enableTracking = false);
        Task<IPaginate<User>> Find(UserFilter userFilter, FetchOptions fetchOptions,
            Func<IQueryable<User>, IIncludableQueryable<User, object>> include = null,
            int page = 1,
            int size = 4,
            bool enableTracking = false);
    }
}
