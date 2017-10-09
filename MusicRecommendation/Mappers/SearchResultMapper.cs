using MusicRecommendation.Mappers.Interfaces;
using MusicRecommendation.Models;
using MusicRecommendation.ViewModels;
using System.Linq;

namespace MusicRecommendation.Mappers
{
    public class SearchResultMapper : ISearchResultMapper
    {
        public RandomTrackVM MapToRandomTrackViewModel(SpotifyTracksResponse randomSearchResponse)
        {
            return randomSearchResponse.Tracks.Items.Select(x => new RandomTrackVM
            {
                Name = x.Name,
                Artist = x.Artists[0].Name,
                ArtistId = x.Artists[0].Id,
                //Href = x.Href,
                PreviewUrl = x.Preview_url,
                ImageUrl = x.Album.Images[0].Url,
                //Uri = x.Uri
            }).First();
        }

        public SearchResultVM MapToViewModel(SpotifyRecommendationsResult _recommendationResult)
        {
            var searchResultVM = new SearchResultVM
            {
                Tracks = _recommendationResult.Tracks.Select(x => new Track
                {
                    Name = x.Name,
                    Artist = x.Artists[0].Name,
                    ArtistId = x.Artists[0].Id,
                    //Href = x.Href,
                    PreviewUrl = x.PreviewUrl,
                    //Uri = x.Uri,
                    ImageUrl = x.Album.Images[0].Url

                }).Where(x => x.PreviewUrl != null).Take(10).ToList(),
            };
            return searchResultVM;
        }
    }


}
