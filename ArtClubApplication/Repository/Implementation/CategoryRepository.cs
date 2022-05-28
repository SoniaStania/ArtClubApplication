using ArtClubApp.Interfaces;
using ArtClubApp.Models;

namespace ArtClubApp.Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category { Name = "Painting", Description = "This is an event with the most beautiful painting for those who loves our Art Club" },
                    new Category { Name = "Pottery", Description = "This is an event to create whatever you want and to use your imagination!" },
                    new Category { Name = "The art of sculpture", Description = "This is for those who loves sculpture!" },
                    new Category { Name = "Rock&Roll", Description = "We're waiting for you to see your talent at singing!" },
                    new Category { Name = "Graffiti", Description = "This is for those who like to reinterpret the art!" }



                };
            }
        }
    }
}

    

