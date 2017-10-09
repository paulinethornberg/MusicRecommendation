using Newtonsoft.Json;

namespace MusicRecommendation.Models
{
    public class SearchArtistResponse
    {
        [JsonProperty("artists")]
        public SpotifyArtistsCollection Artists { get; set; }
    }
}