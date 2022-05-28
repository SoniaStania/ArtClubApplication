using System.ComponentModel.DataAnnotations;

namespace ArtClubApp.Models
{
    public class Payment
    { [Key]
        public int PaymentId { get; set; }


        [Required]
        public string? CurrencyCode { get; set; }
        [Required(ErrorMessage = "Please Enter The Code!")]


        public string? Type { get; set; }

     
        public DateTime Date { get; set; }
    }
}
