using MusicRecommendation.Mappers;
using MusicRecommendation.Mappers.Interfaces;
using MusicRecommendation.Models;
using MusicRecommendation.Services;
using MusicRecommendation.ViewModels;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace MusicRecommendation.UnitTests
{
    public class SearchResultMapperTests :TestSpecification
    {
        private readonly ISearchResultMapper _searchResultMapper;
        private SpotifyRecommendationsResult _recommendationResult;
        private SearchResultVM _searchResultVm;

        public SearchResultMapperTests()
        {
            _searchResultMapper = new SearchResultMapper();
            Setup();
        }
        protected override void Given()
        {
            base.Given();
            _recommendationResult = new SpotifyRecommendationsResult
            {
                Tracks = new List<SpotifyTrack>
                {
                    new SpotifyTrack
                    {
                        Name = "testName",
                        Id = "000000",
                        Popularity = 1,
                        PreviewUrl = "this is the previewUrl",
                        Type = "type",
                        Uri = "uriuriuri",
                        Artists = new List<SpotifyArtist>
                        {
                            new SpotifyArtist
                            {
                                Name = "Beyonce",
                                Id = "11111"
                            }
                        }
                    }
                }
            };
        }

        protected override void When()
        {
            _searchResultVm = _searchResultMapper.MapToViewModel(_recommendationResult);
        }

        [Fact]
        public void It_should_map_name_of_tracks()
        {
            _searchResultVm.Tracks[0].Name.ShouldBe("testName");

        }

        [Fact]
        public void It_should_map_the_previewUrl_of_tracks()
        {
            _searchResultVm.Tracks[0].PreviewUrl.ShouldBe("this is the previewUrl");
        }

        [Fact]
        public void It_should_map_the_artist_of_tracks()
        {
            _searchResultVm.Tracks[0].Artist.ShouldBe("Beyonce");
            _searchResultVm.Tracks[0].ArtistId.ShouldBe("11111");
        }
    }
}