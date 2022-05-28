using ArtClubApp.Models;

namespace ArtClubApplication.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public string? Name { get; set; }  

        public List<Payment> Payments { get; set; } = new List<Payment>();  
        public int Total { get; set; }
    }
}
