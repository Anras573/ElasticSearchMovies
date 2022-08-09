using ElasticSearchMovies.Application.Searchers;
using ElasticSearchMovies.Domain.Movies;
using ElasticSearchMovies.Domain.Searches;
using ElasticSearchMovies.Integration.ElasticSearch.Searchers.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchMovies.Integration.ElasticSearch.Searchers
{
    public class MovieSearcher : IMovieSearcher
    {
        private readonly MovieElasticClientFactory _elasticClientFactory;

        public MovieSearcher(MovieElasticClientFactory elasticClientFactory)
        {
            _elasticClientFactory = elasticClientFactory;
        }

        public async Task<SearchResponse> ListAsync()
        {
            var result = await _elasticClientFactory
                .CreateClient()
                .SearchAsync<Models.Movie>(s => s
                    .From(0)
                    .Size(10)
                    .Sort(s => s.Descending(f => f.Published))
                    .Aggregations(a => a.SignificantText(nameof(Movie.Genres), t => t.Field(f => f.Genres))));

            var aggregations = Mapper.MapAggregations(result.Aggregations);
            var hits = result
                    .Documents
                    .Select(Mapper.Map)
                    .ToList();

            return new SearchResponse()
            {
                Aggregations = aggregations,
                Hits = hits,
                Page = 1,
                TotalHits = result.Total
            };
        }

        public async Task<List<Movie>> QuickSearchAsync(string query)
        {
            var result = await _elasticClientFactory
                .CreateClient()
                .SearchAsync<Models.Movie>(s => s
                    .From(0)
                    .Size(10)
                    .Query(q => q
                        .Match(m => m
                            .Field(f => f.Title)
                            .Query(query))));

            return result
                .Documents
                .Select(Mapper.Map)
                .ToList();
        }
    }
}
