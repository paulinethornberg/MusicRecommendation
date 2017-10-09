using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecommendation.ViewModels
{
    public class SearchResultVM
    {
        public IList<Track> Tracks { get; set; }
    }

    public class Track
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string ArtistId { get; set; }
        public string ImageUrl { get; set; }
        public string PreviewUrl { get; set; }
        public bool ChosenForFineTuning { get; set; }
    }
}
