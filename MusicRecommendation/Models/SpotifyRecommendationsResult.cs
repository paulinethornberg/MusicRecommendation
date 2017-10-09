using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecommendation.Models
{
    public class SpotifyRecommendationsResult
    {
        [JsonProperty("tracks")]
        public IList<SpotifyTrack> Tracks { get; set; }

        [JsonProperty("seeds")]
        public IList<SpotifySeedObject> Seeds { get; set; }
    }

}
