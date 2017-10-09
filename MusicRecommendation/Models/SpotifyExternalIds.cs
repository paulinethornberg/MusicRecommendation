using Newtonsoft.Json;

namespace MusicRecommendation.Models
{
    public class SpotifyExternalIds
    {
        [JsonProperty("isrc")]
        public string Isrc { get; set; }
    }
}