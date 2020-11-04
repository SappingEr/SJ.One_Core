using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SJ.One_Core.Service.Paging
{
    public static class Paging
    {
        public static async Task<IPaginate<T>> PagingAsync<T>(this IQueryable<T> source, int page, int size,
            int from = 0)
        {
            int index = page - 1;
            if (from > index) throw new ArgumentException("From <= Index");

            var count = await source.CountAsync();
            var items = await source.Skip((index - from) * size)
                .Take(size).ToListAsync();

            var list = new Paginate<T>
            {
                Index = index,
                Size = size,
                From = from,
                Count = count,
                Page = page,
                Items = items,
                Pages = (int)Math.Ceiling(count / (double)size)
            };

            return list;
        }
    }
}
