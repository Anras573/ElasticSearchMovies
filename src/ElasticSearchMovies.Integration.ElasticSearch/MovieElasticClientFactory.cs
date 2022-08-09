using Nest;

namespace ElasticSearchMovies.Integration.ElasticSearch
{
    public class MovieElasticClientFactory
    {
        private readonly MovieElasticSearchConfiguration _configuration;

        internal MovieElasticClientFactory(MovieElasticSearchConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ElasticClient CreateClient()
        {
            var settings = new ConnectionSettings(_configuration.Uri)
                .DefaultIndex(_configuration.DefaultIndex ?? "Movies");

            return new ElasticClient(settings);
        }
    }
}
