using System.Collections.Generic;

namespace SJ.One_Core.Service.Paging
{
    class Paginate<T> : IPaginate<T>
    {
        public int From { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
        public List<T> Items { get; set; }
        public bool HasPrevious => Index - From > 0;
        public bool HasNext => Index - From + 1 < Pages;
    }
}
