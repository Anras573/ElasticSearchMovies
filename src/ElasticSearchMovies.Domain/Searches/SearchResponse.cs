using ElasticSearchMovies.Domain.Movies;
using System.Collections.Generic;

namespace ElasticSearchMovies.Domain.Searches
{
    public class SearchResponse
    {
        public List<Movie> Hits { get; set; }
        public long TotalHits { get; set; }
        public int Page { get; set; }
        public SearchResponseAggregations Aggregations { get; set; }
    }

    public class SearchResponseAggregations
    {
        public List<KeyValuePair<string, long>> Genres { get; set; }
    }
}
