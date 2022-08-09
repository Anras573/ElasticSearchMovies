using ElasticSearchMovies.Domain.Finances;
using ElasticSearchMovies.Domain.Movies;
using ElasticSearchMovies.Domain.Searches;
using Nest;
using System.Collections.Generic;
using System.Linq;

namespace ElasticSearchMovies.Integration.ElasticSearch.Searchers.Mappers
{
    internal static class Mapper
    {
        public static Movie Map(Models.Movie movie)
        {
            return new Movie
            {
                Actors = movie.Actors,
                AverageVote = movie.AverageVote,
                Budget = Money.Create(CurrencyMapper.Map(movie.BudgetCurrency), movie.Budget),
                Country = movie.Country,
                CriticReviewScores = movie.CriticReviewScores,
                Description = movie.Description,
                Director = movie.Director,
                DurationInMinutes = movie.DurationInMinutes,
                Genres = movie.Genres,
                GrossIncomeForUSA = Money.Create(CurrencyMapper.Map(movie.GrossIncomeForUSACurrency), movie.GrossIncomeForUSA),
                Id = ExternalId.Create(movie.Id),
                Languages = movie.Languages,
                MetaScore = movie.MetaScore,
                NumberOfVotes = movie.NumberOfVotes,
                OriginalTitle = movie.OriginalTitle,
                ProductionCompany = movie.ProductionCompany,
                Published = movie.Published,
                Title = movie.Title,
                UserReviewScores = movie.UserReviewScores,
                WorldWideGrossIncome = Money.Create(CurrencyMapper.Map(movie.WorldWideGrossIncomeCurrency), movie.WorldWideGrossIncome),
                Writers = movie.Writers,
                Year = movie.Year
            };
        }

        public static SearchResponseAggregations MapAggregations(AggregateDictionary aggregateDictionary)
        {
            var genres = MapAggregation(nameof(Movie.Genres), aggregateDictionary);

            return new SearchResponseAggregations()
            {
                Genres = genres
            };
        }

        private static List<KeyValuePair<string, long>> MapAggregation(string key, AggregateDictionary aggregateDictionary)
        {
            return aggregateDictionary
                .SignificantText(key)
                .Buckets
                .Select(b => KeyValuePair.Create(b.Key, b.DocCount))
                .OrderBy(kvp => kvp.Key)
                .ToList();
        }
    }
}
