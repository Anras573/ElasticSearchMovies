using ElasticSearchMovies.Application.Indexers;
using ElasticSearchMovies.Application.Searchers;
using ElasticSearchMovies.Integration.ElasticSearch.Indexers;
using ElasticSearchMovies.Integration.ElasticSearch.Searchers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ElasticSearchMovies.Integration.ElasticSearch
{
    public static class ElasticSearchDependencyInjectionBuilder
    {
        public static IServiceCollection AddElasticSearch(this IServiceCollection services, Func<MovieElasticSearchConfiguration> configurationBuilder)
        {
            var configuration = configurationBuilder.Invoke();

            services.AddSingleton<MovieElasticClientFactory>((_) => new MovieElasticClientFactory(configuration));
            services.AddSingleton<IMovieIndexer, MovieIndexer>();
            services.AddSingleton<IMovieSearcher, MovieSearcher>();

            return services;
        }
    }
}
