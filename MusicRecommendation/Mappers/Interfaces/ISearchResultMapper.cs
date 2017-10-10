using MusicRecommendation.Models;
using MusicRecommendation.ViewModels;

namespace MusicRecommendation.Mappers.Interfaces
{
    public interface ISearchResultMapper
    {
        SearchResultVM MapToViewModel(SpotifyRecommendationsResult recommendationResult);
        RandomTrackVM MapToRandomTrackViewModel(SpotifyTracksResponse randomSearchResponse);
    }


}
