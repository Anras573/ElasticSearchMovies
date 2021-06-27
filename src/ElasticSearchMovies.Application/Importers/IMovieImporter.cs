using ElasticSearchMovies.Domain.Movies;
using System.Collections.Generic;

namespace ElasticSearchMovies.Application.Importers
{
    public interface IMovieImporter
    {
        IEnumerable<Movie> Import();
    }
}
