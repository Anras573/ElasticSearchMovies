using ElasticSearchMovies.Domain.Movies;
using System.Collections.Generic;

namespace ElasticSearchMovies.Application.Movies
{
    public interface IMovieService
    {
        IEnumerable<Movie> Import();
    }
}
