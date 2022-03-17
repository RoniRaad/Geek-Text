namespace Geek_Text.Models
{
    public class UserRating
    {
        public int ID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        public int UserId { get; set; }
        public int BookISBN { get; set; }
    }
}
