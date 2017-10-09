using Newtonsoft.Json;

namespace MusicRecommendation.Models
{
    public class SpotifySearchArtistResponse
    {
        [JsonProperty("artists")]
        public SpotifyArtistsCollection Artists { get; set; }
    }
}