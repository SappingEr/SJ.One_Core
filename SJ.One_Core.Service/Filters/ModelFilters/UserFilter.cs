namespace SJ.One_Core.Service.Filters.ModelFilters
{
    public class UserFilter
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string DOB { get; set; }
        public DateRange DOBRange { get; set; }
    }
}
