using ArtClubApp.Models;

namespace ArtClubApp.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
