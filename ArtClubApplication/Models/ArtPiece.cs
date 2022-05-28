using System.ComponentModel.DataAnnotations;

namespace ArtClubApp.Models
{
    public class ArtPiece
    { 
        [Key]
        public int PieceId { get; set; }
        public string? Name { get; set; }  
        public string? Type { get; set; }  
        public string? PhotoURL { get; set; }  
        public string? Description { get; set; } 
        public DateTime DateTime { get; set; }
      

        


    }
}
