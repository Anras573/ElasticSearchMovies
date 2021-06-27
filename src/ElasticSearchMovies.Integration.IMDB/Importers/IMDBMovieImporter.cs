using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using ElasticSearchMovies.Application.Importers;
using ElasticSearchMovies.Domain.Movies;
using ElasticSearchMovies.Integration.IMDB.Models;
using ElasticSearchMovies.Integration.IMDB.Models.Mappers;

namespace ElasticSearchMovies.Integration.IMDB.Importers
{
    public class IMDBMovieImporter : IMovieImporter
    {
        public IEnumerable<Movie> Import()
        {
            using var reader = new StreamReader(Constants.RelativeDataPath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "," });

            csv.Context.RegisterClassMap<MovieClassMap>();
            var movies = csv.GetRecords<IMDbMovie>();

            foreach (var movie in movies)
            {
                yield return Mapper.Map(movie);
            }
        }
    }
}
