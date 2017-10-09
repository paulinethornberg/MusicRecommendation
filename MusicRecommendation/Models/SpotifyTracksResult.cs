using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecommendation.Models
{
    public class SpotifyTracksResponse
    {
        [JsonProperty("tracks")]
        public SpotifyTrackSearch Tracks { get; set; }
    }

    public class SpotifyTrackSearch
    {
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("items")]
        public IList<Item> Items { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("offset")]

        public int Offset { get; set; }
        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("total")]

        public int Total { get; set; }
    }
    public class Item
    {
        [JsonProperty("album")]

        public Album Album { get; set; }
        [JsonProperty("artists")]

        public IList<Artist> Artists { get; set; }
        [JsonProperty("available_markets")]
        public IList<string> Available_markets { get; set; }
        [JsonProperty("disc_number")]

        public int Disc_number { get; set; }
        [JsonProperty("duration_ms")]

        public int Duration_ms { get; set; }
        [JsonProperty("explicit")]

        public bool Explicit { get; set; }
        [JsonProperty("external_ids")]

        public ExternalIds External_ids { get; set; }
        [JsonProperty("external_urls")]

        public ExternalUrls External_urls { get; set; }
        [JsonProperty("href")]

        public string Href { get; set; }
        [JsonProperty("id")]

        public string Id { get; set; }
        [JsonProperty("name")]

        public string Name { get; set; }
        [JsonProperty("popularity")]

        public int Popularity { get; set; }
        [JsonProperty("preview_url")]

        public string Preview_url { get; set; }
        [JsonProperty("track_number")]


        public int Track_number { get; set; }
        [JsonProperty("type")]

        public string Type { get; set; }
        [JsonProperty("uri")]

        public string Uri { get; set; }
    }
    public class ExternalUrls
    {
        [JsonProperty("spotify")]

        public string Spotify { get; set; }
    }

    public class Artist
    {
        [JsonProperty("external_urls")]

        public ExternalUrls External_urls { get; set; }
        [JsonProperty("href")]

        public string Href { get; set; }
        [JsonProperty("id")]

        public string Id { get; set; }
        [JsonProperty("name")]

        public string Name { get; set; }
        [JsonProperty("type")]

        public string Type { get; set; }
        [JsonProperty("uri")]

        public string Uri { get; set; }
    }

    public class Image
    {
        [JsonProperty("height")]

        public int Height { get; set; }
        [JsonProperty("url")]

        public string Url { get; set; }
        [JsonProperty("width")]

        public int Width { get; set; }
    }

    public class Album
    {
        [JsonProperty("album_type")]

        public string Album_type { get; set; }
        [JsonProperty("artists")]

        public IList<Artist> Artists { get; set; }
        [JsonProperty("available_markets")]

        public IList<string> Available_markets { get; set; }
        [JsonProperty("external_urls")]

        public ExternalUrls External_urls { get; set; }
        [JsonProperty("href")]

        public string Href { get; set; }
        [JsonProperty("id")]

        public string Id { get; set; }
        [JsonProperty("images")]

        public IList<Image> Images { get; set; }
        [JsonProperty("name")]

        public string Name { get; set; }

        [JsonProperty("type")]

        public string Type { get; set; }
        [JsonProperty("uri")]

        public string Uri { get; set; }
    }

    public class ExternalIds
    {
        [JsonProperty("isrc")]

        public string Isrc { get; set; }
    }
}
