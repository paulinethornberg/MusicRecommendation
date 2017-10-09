using Flurl;
using MusicRecommendation.Framework;
using MusicRecommendation.Models;
using MusicRecommendation.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicRecommendation.Services
{
    public class SpotifyApiService : ISpotifyApiService
    {
        private HttpClient _client;

        public SpotifyApiService(ISpotifyCLient spotifyClient)
        {
            _client = spotifyClient.GetDefaultClient();
        }

        public async Task<SpotifySearchArtistResponse> SearchArtistsAsync(string artistName)
        {
            var url = new Url("/v1/search");
            url = url.SetQueryParam("q", artistName);
            url = url.SetQueryParam("type", "artist");

            var response = await _client.GetStringAsync(url);
            var artistResponse = JsonConvert.DeserializeObject<SpotifySearchArtistResponse>(response);

            return artistResponse;
        }

        public async Task<SpotifyRecommendationsResult> GetRecommendationWithSingleArtistAsync(string artistId)
        {
            var url = new Url("/v1/recommendations");
            url = url.SetQueryParam("seed_artists", artistId);
            var response = await _client.GetStringAsync(url);
            var recommendationsResult = JsonConvert.DeserializeObject<SpotifyRecommendationsResult>(response);

            return recommendationsResult;
        }

        public async Task<SpotifyRecommendationsResult> GetRecommendationWithMultipleArtistsAsync(string joinedIds)
        {
            var url = new Url("/v1/recommendations");
            url = url.SetQueryParam("seed_artists", joinedIds);
            var response = await _client.GetStringAsync(url);
            var recommendationsResult = JsonConvert.DeserializeObject<SpotifyRecommendationsResult>(response);

            return recommendationsResult;
        }

        public async Task<SpotifyTracksResponse> GetRandomTrackAsync(string randomSearchTerm, int randomOffset)
        {
            var url = new Url("/v1/search");
            url = url.SetQueryParam("q", randomSearchTerm);
            url = url.SetQueryParam("offset", randomOffset);
            url = url.SetQueryParam("type", "track");
            url = url.SetQueryParam("limit", "1");

            var response = await _client.GetStringAsync(url);
            var tracksResponse = JsonConvert.DeserializeObject<SpotifyTracksResponse>(response);

            return tracksResponse;
        }
    }
}