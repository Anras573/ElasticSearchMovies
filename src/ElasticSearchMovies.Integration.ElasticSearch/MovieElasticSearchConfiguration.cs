using System;

namespace ElasticSearchMovies.Integration.ElasticSearch
{
    public class MovieElasticSearchConfiguration
    {
        public Uri Uri { get; set; }
        public string DefaultIndex { get; set; }
    }
}
