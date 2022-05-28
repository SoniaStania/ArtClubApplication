using ArtClubApp.Interfaces;
using ArtClubApp.Models;

namespace ArtClubApp.Repository.Implementation
{
    public class ArtEventRepository : IArtEventRepository
    {
        
        private readonly ICategoryRepository _categoryRepository = new CategoryRepository();

        public IEnumerable<ArtEvent> Events { 
            get
            {
                return new List<ArtEvent>
                {
                    new ArtEvent
                    {
                        Name ="Painting",
                        ShortDescription = "I dream my paintings, and then I paint my dreams.",
                        LongDescription ="This event is about creation, feelings, expressions and we're waiting for you to join in our club!",
                        Price =500,
                        PhotoURL="images/painting.jpg",
                        Category = _categoryRepository.Categories.First(),
                        Status="Available",
                        IsPreferedEvent=true
                    },
                    new ArtEvent
                    {
                        Name="Pottery",
                        ShortDescription="All you need is a pottery object",
                        LongDescription="Pottery, one of the oldest and most widespread of the decorative arts, consisting of objects made of clay and hardened with heat. The objects made are commonly useful ones, such as vessels for holding liquids or plates or bowls from which food can be served.",
                        Price=400,
                        PhotoURL="images/pottery.jpg",
                        Category= _categoryRepository.Categories.First(),
                        Status="Available",
                        IsPreferedEvent=true
                    },
                    new ArtEvent
                    {
                        Name="The art of sculpture",
                        ShortDescription="Sculpture is the art of intelligence!",
                        LongDescription="Sculpture has been used to create original and fascinating works of art and also to recreate and portray figures, characters, objects, people and animals. These figures may be a fully realistic representation or they may be entirely abstract, depicting the artist's vision of a specific aspect.",
                        Price=600,
                        PhotoURL="images/sculpture.jpg",
                        Category=_categoryRepository.Categories.First(),
                        Status="Available",
                        IsPreferedEvent=true

                    },
                    new ArtEvent
                    {
                        Name="Rock&Roll",
                        ShortDescription="Rock 'n' roll is instant coffee.",
                        LongDescription="Rock and roll (often written as rock & roll, rock 'n' roll, or rock 'n roll) is a genre of popular music that evolved in the United States during the late 1940s and early 1950s. It originated from black American music such as gospel, jump blues, jazz, boogie woogie, rhythm and blues, as well as country music.",
                        Price=700,
                        PhotoURL="images/rock&roll.png",
                        Category=_categoryRepository.Categories.First(),
                        Status="Available",
                        IsPreferedEvent=true,
                    }
                   




                    };
                }
            }
        public IEnumerable<ArtEvent> PreferedEvents { get; set; }
        IEnumerable<ArtEvent> IArtEventRepository.ArtEvents { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ArtEvent GetArtEventById(int eventId)
        {
            throw new NotImplementedException();
        }

        public ArtEvent GetEventById(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
