using ElasticSearchMovies.Domain.Finances;
using ElasticSearchMovies.Domain.Movies;
using System;
using System.Linq;

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
                Id = ExternalId.Create(movie.IMDbTitleId),
                Genres = movie.Genres,
                GrossIncomeForUSA = ParseMoney(movie.GrossIncomeForUSA),
                Languages = movie.Language.Split(new string[] { ", " }, StringSplitOptions.None).ToList(),
                MetaScore = movie.MetaScore,
                NumberOfVotes = movie.NumberOfVotes,
                OriginalTitle = movie.OriginalTitle,
                ProductionCompany = movie.ProductionCompany,
                Published = movie.DatePublished,
                Title = movie.Title,
                UserReviewScores = movie.UserReviewScores,
                WorldWideGrossIncome = ParseMoney(movie.WorldWideGrossIncome),
                Writers = movie.Writer.Split(new string[] { ", " }, StringSplitOptions.None).ToList(),
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
