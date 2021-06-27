using ElasticSearchMovies.Domain.Finances;
using ElasticSearchMovies.Domain.Movies;

namespace ElasticSearchMovies.Integration.IMDB.Models.Mappers
{
    internal static class Mapper
    {
        public static Movie Map(IMDbMovie movie)
        {
            return new Movie
            {
                Actors = movie.Actors,
                AverageVote = movie.AverageVote,
                Budget = ParseMoney(movie.Budget),
                Country = movie.Country,
                CriticReviewScores = movie.CriticReviewScores,
                Description = movie.Description,
                Director = movie.Director,
                DurationInMinutes = movie.DurationInMinutes,
                Genres = movie.Genres,
                GrossIncomeForUSA = ParseMoney(movie.GrossIncomeForUSA),
                Id = MovieId.Create(movie.IMDbTitleId),
                Language = movie.Language,
                MetaScore = movie.MetaScore,
                NumberOfVotes = movie.NumberOfVotes,
                OriginalTitle = movie.OriginalTitle,
                ProductionCompany = movie.ProductionCompany,
                Published = movie.DatePublished,
                Title = movie.Title,
                UserReviewScores = movie.UserReviewScores,
                WorldWideGrossIncome = ParseMoney(movie.WorldWideGrossIncome),
                Writer = movie.Writer,
                Year = movie.Year
            };
        }

        private static Money ParseMoney(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return Money.Create(Currency.USD, 0.0m);
            }

            var inputSplit = input.Split(" ");
            var currency = CurrencyMapper.Map(inputSplit[0]);
            var value = decimal.Parse(inputSplit[1]);

            return Money.Create(currency, value);
        }
    }
}
