using System;
using System.Collections.Generic;

namespace ElasticSearchMovies.Integration.ElasticSearch.Models
{
    internal class Movie
    {
        public string Id { get; init; }
        public string Title { get; init; }
        public string OriginalTitle { get; init; }
        public int Year { get; init; }
        public DateTime Published { get; init; }
        public List<string> Genres { get; init; }
        public int DurationInMinutes { get; init; }
        public string Country { get; init; }
        public List<string> Languages { get; init; }
        public string Director { get; init; }
        public List<string> Writers { get; init; }
        public string ProductionCompany { get; init; }
        public List<string> Actors { get; init; }
        public string Description { get; init; }
        public double? AverageVote { get; init; }
        public int NumberOfVotes { get; init; }
        public decimal Budget { get; init; }
        public string BudgetCurrency { get; init; }
        public decimal GrossIncomeForUSA { get; init; }
        public string GrossIncomeForUSACurrency { get; init; }
        public decimal WorldWideGrossIncome { get; init; }
        public string WorldWideGrossIncomeCurrency { get; init; }
        public double? MetaScore { get; init; }
        public double? UserReviewScores { get; init; }
        public double? CriticReviewScores { get; init; }
    }
}
