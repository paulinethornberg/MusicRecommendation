using MusicRecommendation.Models;
using MusicRecommendation.ViewModels;
using System.Threading.Tasks;

namespace MusicRecommendation.Services.Interfaces
{
    public interface IRecommendationService
    {
        Task<SpotifyRecommendationsResult> RecommendationWithArtist(string artist);
        Task<SpotifyRecommendationsResult> FineTuneRecommendation(SearchResultVM searchResultVM);
        Task<SpotifyTracksResponse> GetRandom();
    }
}
