using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicRecommendation.Services.Interfaces;
using MusicRecommendation.Mappers;
using System.Linq;
using MusicRecommendation.Services;
using System.Collections.Generic;
using MusicRecommendation.ViewModels;
using MusicRecommendation.Mappers.Interfaces;
using MusicRecommendation.Models;

namespace MusicRecommendation.Controllers
{
    public class SearchController : Controller
    {
        private ISpotifyApiService _spotifyService;
        private ISearchResultMapper _searchResultMapper;
        private IRecommendationService _recommendationService;

        public SearchController(ISpotifyApiService spotifyService, ISearchResultMapper mapper, IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
            _spotifyService = spotifyService;
            _searchResultMapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Search(string artist)
        {
            try
            {
                //var result = await _recommendationService.Recommend(artist);
                //var searchResultVM = _searchResultMapper.MapToViewModel(result);
                //return View(searchResultVM);
                //--------------------------------------------------------------------------------------------------
               
                var recommendationResult = await _recommendationService.RecommendationWithArtist(artist);
                var searchResultVM = _searchResultMapper.MapToViewModel(recommendationResult);

                return View(searchResultVM);
            }
            catch (System.Exception)
            {
                //log exception
                return RedirectToAction("Error"); 
            }
          
        }

        [HttpPost]
        public async Task<IActionResult> FineTune(SearchResultVM searchResultVM)
        {
            if(searchResultVM.Tracks.All(track => track.ChosenForFineTuning == false))
                return View("Search", searchResultVM);
            try
            {
                var fineTunedResult = await _recommendationService.FineTuneRecommendation(searchResultVM);
                searchResultVM = _searchResultMapper.MapToViewModel(fineTunedResult);

                return View("Search", searchResultVM);
            }
            catch (System.Exception)
            {
                //log exception
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> Random()
        {
            try
            {
                var randomSearchResponse = new SpotifyTracksResponse(); 
                int trackCount = 0;
                while(trackCount == 0)
                {
                    randomSearchResponse = await _recommendationService.GetRandom();
                    if (randomSearchResponse.Tracks.Items.Count > 0)
                        trackCount++;
                }
                var viewModel = _searchResultMapper.MapToRandomTrackViewModel(randomSearchResponse);
                return View(viewModel);
            }
            catch (System.Exception)
            {
                //log exception
                return RedirectToAction("Error");
            }
        }

        public IActionResult Error()
        {
            ViewData["ErrorMessage"] = "Ouuups, something went wrong!";
            return View();
        }
    }
}