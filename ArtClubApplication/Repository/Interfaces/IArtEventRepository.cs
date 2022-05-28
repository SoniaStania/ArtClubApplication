using ArtClubApp.Models;

namespace ArtClubApp.Interfaces
{
    public interface IArtEventRepository
    {
        IEnumerable<ArtEvent> ArtEvents { get; set; }
        IEnumerable<ArtEvent> PreferedEvents { get; set; }
        ArtEvent GetArtEventById(int eventId); 

        
    }
}
