using System.ComponentModel.DataAnnotations;

namespace ArtClubApp.Models
{
    public class Rezervation
    {
        [Key]
        public int RezervationId { get; set; }

        [Display(Name = "Host")]
        public  User? Users {get; set;}
        public ArtEvent? ArtEvents {get; set;}   
        
           
    }
}
