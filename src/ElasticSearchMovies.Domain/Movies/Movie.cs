﻿using System;
using System.Collections.Generic;
using ElasticSearchMovies.Domain.Finances;

namespace ElasticSearchMovies.Domain.Movies
{
    public record Movie
    {
        public ExternalId Id { get; set; }
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
        public Money Budget { get; init; }
        public Money GrossIncomeForUSA { get; init; }
        public Money WorldWideGrossIncome { get; init; }
        public double? MetaScore { get; init; }
        public double? UserReviewScores { get; init; }
        public double? CriticReviewScores { get; init; }
    }
}
