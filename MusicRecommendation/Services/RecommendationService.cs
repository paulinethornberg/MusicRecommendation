using MusicRecommendation.Models;
using MusicRecommendation.Services.Interfaces;
using MusicRecommendation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecommendation.Services
{
    public class RecommendationService : IRecommendationService
    {
        private ISpotifyApiService _spotifyService;

        public RecommendationService(ISpotifyApiService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async Task<SpotifyRecommendationsResult> RecommendationByArtist(string artist)
        {
            var searchArtistResponse = await _spotifyService.SearchArtistsAsync(artist);
            var artistId = searchArtistResponse.Artists.Items[0].Id;

            return await _spotifyService.GetRecommendationWithSingleArtistAsync(artistId);
        }

        public async Task<SpotifyRecommendationsResult> FineTuneRecommendation(SearchResultVM searchResultVM)
        {
            var listOfIds = new List<string>();
            foreach (var track in searchResultVM.Tracks)
            {
                if (track.ChosenForFineTuning)
                    listOfIds.Add(track.ArtistId);
            }

            //Spotify recommendation-seed only takes 5 parameters
            if (listOfIds.Count > 5)
                listOfIds = listOfIds.Take(5).ToList();
            string joinedIds = string.Join(",", listOfIds);

            return await _spotifyService.GetRecommendationWithMultipleArtistsAsync(joinedIds);
        }

        public async Task<SpotifyTracksResponse> GetRandom()
        {
            var listOfSearchTerms = new List<string> { "a", "e", "i", "o", "u", "y", "å", "ä", "ö" };
            var random = new Random();
            var randomIndex = random.Next(listOfSearchTerms.Count);
            var randomOffset = random.Next(1, 1000);

            return await _spotifyService.GetRandomTrackAsync(listOfSearchTerms[randomIndex], randomOffset);

        }
    }
}
