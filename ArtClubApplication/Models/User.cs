using System.ComponentModel.DataAnnotations;

namespace ArtClubApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Username is Required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 chars")]
        public string? Username { get; set; }
       

      
       
        [Required(ErrorMessage = "Password is Required!")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 20 chars")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }



        [Required(ErrorMessage = "FirstName is Required!")]
        public string? FirstName { get; set; }
       
        public string? LastName { get; set; }
        public string? PhotoURL { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "City is Required!")]
        public string? City { get; set; }
       
        public int Telephone { get; set; }
        public char Flag { get; set; }  
        
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Payment>? Payments { get; set; }
       
    }
}
