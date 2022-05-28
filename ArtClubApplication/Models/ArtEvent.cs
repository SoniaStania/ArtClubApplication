using ArtClubApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace ArtClubApp.Models
{
    public class ArtEvent
    {
        [Key]
        public int EventId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }    
        public string LongDescription { get; set; }
        public bool IsPreferedEvent { get; set; }  
        public decimal Price { get; set; }  
        public string PhotoURL { get; set; }  
        
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }    
        public string Status { get; set; }  
        public DateTime CreatedDate { get; set; }
      
        public ArtResource? ArtResources { get; set; }
      
        public List<Review> Reviews { get; set; } = new List<Review>();

       
    }
}
