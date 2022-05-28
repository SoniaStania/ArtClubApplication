namespace ArtClubApp.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
       
      
        public string? Details { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
