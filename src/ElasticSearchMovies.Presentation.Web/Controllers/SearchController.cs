using ElasticSearchMovies.Application.Searchers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElasticSearchMovies.Presentation.Web.Controllers
{
    public class SearchController : ControllerBase
    {
        private readonly IMovieSearcher _movieSearcher;

        public SearchController(IMovieSearcher movieSearcher)
        {
            _movieSearcher = movieSearcher;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _movieSearcher.ListAsync();

            return new JsonResult(result);
        }

        public async Task<IActionResult> QuickSearch(string query)
        {
            var result = await _movieSearcher.QuickSearchAsync(query);

            return new JsonResult(result);
        }
    }
}
