using Newtonsoft.Json;

namespace MusicRecommendation.Models
{
    public class SpotifyExternalUrls
    {
        [JsonProperty("spotify")]
        public string Spotify { get; set; }
    }
}