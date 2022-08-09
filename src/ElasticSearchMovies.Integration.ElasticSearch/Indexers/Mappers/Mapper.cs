using ElasticSearchMovies.Domain.Finances;
using ElasticSearchMovies.Integration.ElasticSearch.Models;

namespace ElasticSearchMovies.Integration.ElasticSearch.Indexers.Mappers
{
    internal static class Mapper
    {
        public static Movie Map(Domain.Movies.Movie domainMovie)
        {
            var (budget, budgetCurrency) = ParseMoney(domainMovie.Budget);
            var (grossIncomeForUSA, grossIncomeForUSACurrency) = ParseMoney(domainMovie.GrossIncomeForUSA);
            var (worldWideGrossIncome, worldWideGrossIncomeCurrency) = ParseMoney(domainMovie.WorldWideGrossIncome);

            return new Movie()
            {
                Actors = domainMovie.Actors,
                AverageVote = domainMovie.AverageVote,
                Budget = budget,
                BudgetCurrency = budgetCurrency,
                Country = domainMovie.Country,
                CriticReviewScores = domainMovie.CriticReviewScores,
                Description = domainMovie.Description,
                Director = domainMovie.Director,
                DurationInMinutes = domainMovie.DurationInMinutes,
                Genres = domainMovie.Genres,
                GrossIncomeForUSA = grossIncomeForUSA,
                GrossIncomeForUSACurrency = grossIncomeForUSACurrency,
                Id = domainMovie.Id.Value,
                Languages = domainMovie.Languages,
                MetaScore = domainMovie.MetaScore,
                NumberOfVotes = domainMovie.NumberOfVotes,
                OriginalTitle = domainMovie.OriginalTitle,
                ProductionCompany = domainMovie.ProductionCompany,
                Published = domainMovie.Published,
                Title = domainMovie.Title,
                UserReviewScores = domainMovie.UserReviewScores,
                WorldWideGrossIncome = worldWideGrossIncome,
                WorldWideGrossIncomeCurrency = worldWideGrossIncomeCurrency,
                Writers = domainMovie.Writers,
                Year = domainMovie.Year
            };
        }

        private static (decimal budget, string budgetCurrency) ParseMoney(Money money)
        {
            var value = money.Value;
            var currency = money.Currency.ToString();

            return (value, currency);
        }
    }
}
