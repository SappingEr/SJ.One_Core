namespace SJ.One_Core.Service.Filters
{
    public abstract class BaseRange<T>
    {
        public T From { get; set; }
        public T To { get; set; }
    }
}
