﻿using MusicRecommendation.Services;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MusicRecommendation.Models
{
    public class SpotifyAlbum
    {
        [JsonProperty("album_type")]
        public string AlbumType { get; set; }

        [JsonProperty("artists")]
        public IList<SpotifyArtist> Artists { get; set; }

        [JsonProperty("available_markets")]
        public IList<string> AvailableMarkets { get; set; }

        [JsonProperty("external_urls")]
        public SpotifyExternalUrls ExternalUrls { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public IList<SpotifyImage> Images { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}