using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicRecommendation.Services.Interfaces;
using System.Linq;
using MusicRecommendation.ViewModels;
using MusicRecommendation.Mappers.Interfaces;
using MusicRecommendation.Models;

namespace MusicRecommendation.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchResultMapper _searchResultMapper;
        private readonly IRecommendationService _recommendationService;

        public SearchController( ISearchResultMapper mapper, IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
            _searchResultMapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Search(string artist)
        {
            try
            {
                var recommendationResult = await _recommendationService.RecommendationByArtist(artist);
                var searchResultVm = _searchResultMapper.MapToViewModel(recommendationResult);

                return View(searchResultVm);
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