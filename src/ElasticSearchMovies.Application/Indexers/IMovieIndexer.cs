using ElasticSearchMovies.Domain.Movies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElasticSearchMovies.Application.Indexers
{
    public interface IMovieIndexer
    {
        Task IndexMovieAsync(Movie movie);
        Task IndexMoviesAsync(List<Movie> batch);
    }
}
