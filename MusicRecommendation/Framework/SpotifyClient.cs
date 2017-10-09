using MusicRecommendation.Services.Interfaces;
using System;
using System.Net.Http;

namespace MusicRecommendation.Framework
{
    public class SpotifyClient : ISpotifyCLient
    {
        private const string ClientId = "996d0037680544c987287a9b0470fdbb";
        private const string ClientSecret = "5a3c92099a324b8f9e45d77e919fec13";
        protected const string BaseUrl = "https://api.spotify.com/";

        public HttpClient GetDefaultClient()
        {
            var authHandler = new SpotifyAuthClientCredentialsHttpMessageHandler(
                 ClientId,
                 ClientSecret,
                 new HttpClientHandler());

            var client = new HttpClient(authHandler)
            {
                BaseAddress = new Uri(BaseUrl)
            };

            return client;
        }
    }
}
