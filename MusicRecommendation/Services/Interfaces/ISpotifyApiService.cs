using MusicRecommendation.Models;
using System.Threading.Tasks;

namespace MusicRecommendation.Services.Interfaces
{
    public interface ISpotifyApiService
    {
        Task<SearchArtistResponse> SearchArtistsAsync(string artistName);
        Task<SpotifyRecommendationsResult> GetRecommendationWithSingleArtistAsync(string artistId);
        Task<SpotifyRecommendationsResult> GetRecommendationWithMultipleArtistsAsync(string listOfId);
        Task<SpotifyTracksResponse> GetRandomTrackAsync(string randomSearchTerm, int randomOffset);
    }
}