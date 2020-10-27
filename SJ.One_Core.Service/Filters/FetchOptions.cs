namespace SJ.One_Core.Service.Filters
{
    public class FetchOptions
    {
        public int Index { get; set; }
        public int Count { get; set; }
        public string SortExpression { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
