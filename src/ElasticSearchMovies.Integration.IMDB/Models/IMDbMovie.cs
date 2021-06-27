using System;
using System.Collections.Generic;

namespace ElasticSearchMovies.Integration.IMDB.Models
{
    internal class IMDbMovie
    {
        public string IMDbTitleId { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public int Year { get; set; }
        public DateTime DatePublished { get; set; }
        public List<string> Genres { get; set; }
        public int DurationInMinutes { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string ProductionCompany { get; set; }
        public List<string> Actors { get; set; }
        public string Description { get; set; }
        public double? AverageVote { get; set; }
        public int NumberOfVotes { get; set; }
        public string Budget { get; set; }
        public string GrossIncomeForUSA { get; set; }
        public string WorldWideGrossIncome { get; set; }
        public double? MetaScore { get; set; }
        public double? UserReviewScores { get; set; }
        public double? CriticReviewScores { get; set; }
    }
}
