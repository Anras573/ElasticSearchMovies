using ElasticSearchMovies.Integration.IMDB.Importers;
using System;

namespace ElasticSearchMovies.Test.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var movieImporter = new IMDBMovieImporter();
            var movies = movieImporter.Import();

            foreach (var movie in movies)
            {
                Console.WriteLine($"{movie.Title} ({movie.Year})");
            }
        }
    }
}
