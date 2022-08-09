using ElasticSearchMovies.Domain.Movies;
using ElasticSearchMovies.Domain.Searches;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElasticSearchMovies.Application.Searchers
{
    public interface IMovieSearcher
    {
        Task<SearchResponse> ListAsync();
        Task<List<Movie>> QuickSearchAsync(string query);
    }
}
