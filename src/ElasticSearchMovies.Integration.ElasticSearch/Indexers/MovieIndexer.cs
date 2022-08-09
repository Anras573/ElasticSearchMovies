using ElasticSearchMovies.Application.Indexers;
using ElasticSearchMovies.Domain.Movies;
using ElasticSearchMovies.Integration.ElasticSearch.Indexers.Mappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElasticSearchMovies.Integration.ElasticSearch.Indexers
{
    public class MovieIndexer : IMovieIndexer
    {
        private readonly MovieElasticClientFactory _elasticClientFactory;

        public MovieIndexer(MovieElasticClientFactory elasticClientFactory)
        {
            _elasticClientFactory = elasticClientFactory;
        }
        public async Task IndexMovieAsync(Movie movie)
        {
            var indexedMovie = Mapper.Map(movie);

            var response = await _elasticClientFactory.CreateClient().IndexDocumentAsync(indexedMovie);

            if (!response.IsValid)
            {
                Console.Error.WriteLine(response.ServerError.Error);
            }
            else
            {
                Console.WriteLine($"Indexed Movie: {indexedMovie.Title} ({indexedMovie.Id})");
            }
        }

        public async Task IndexMoviesAsync(List<Movie> batch)
        {
            var movies = batch.ConvertAll(Mapper.Map);

            var response = await _elasticClientFactory.CreateClient().BulkAsync(descriptor => descriptor.IndexMany(movies));

            if (!response.IsValid)
            {
                Console.Error.WriteLine(response.ServerError.Error);
            }
            else
            {
                Console.WriteLine($"Indexed {batch.Count} Movies!");
            }
        }
    }
}
