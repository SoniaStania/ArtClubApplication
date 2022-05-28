using System.ComponentModel.DataAnnotations;

namespace ArtClubApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<ArtEvent>? ArtEvents { get; set; } 

    }
}
