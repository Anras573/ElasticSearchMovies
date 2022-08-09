using ElasticSearchMovies.Application.Indexers;
using ElasticSearchMovies.Integration.ElasticSearch;
using ElasticSearchMovies.Integration.IMDB.Importers;
using ElasticSearchMovies.Shared;
using ElasticSearchMovies.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchMovies.Test.ConsoleApplication
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            var movieImporter = new IMDBMovieImporter();
            var movies = movieImporter.Import();

            var indexer = host.Services.GetRequiredService<IMovieIndexer>();

            var batches = movies.Batch(100);
            var batchNumber = 1;
            foreach (var batch in batches)
            {
                await indexer.IndexMoviesAsync(batch.ToList());
                Console.WriteLine($"Indexed batch {batchNumber}");

                batchNumber++;
            }

            await host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    ConfigureServices(services));

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddElasticSearch(() => new MovieElasticSearchConfiguration
            {
                DefaultIndex = $"test-{Constants.IndexName}",
                Uri = new Uri("http://localhost:9200")
            });
        }
    }
}
