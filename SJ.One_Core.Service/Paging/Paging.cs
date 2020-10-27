using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SJ.One_Core.Service.Paging
{
    public static class Paging
    {
        public static async Task<IPaginate<T>> PagingAsync<T>(this IQueryable<T> source, int index, int size,
            int from = 0)
        {
            if (from > index) throw new ArgumentException("From <= Index");

            var count = await source.CountAsync();
            var items = await source.Skip((index - from) * size)
                .Take(size).ToListAsync().ConfigureAwait(false);

            var list = new Paginate<T>
            {
                Index = index,
                Size = size,
                From = from,
                Count = count,
                Items = items,
                Pages = (int)Math.Ceiling(count / (double)size)
            };

            return list;
        }
    }
}
