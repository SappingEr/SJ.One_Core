namespace SJ.One_Core.Models
{
    public class User_Race
    {
        public int UserId { get; set; }
        public Race Race { get; set; }

        public int RaceId { get; set; }
        public User User { get; set; }
    }
}
