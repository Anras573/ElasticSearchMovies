using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElasticSearchMovies.Integration.IMDB.Models.Mappers
{
    internal class MovieClassMap : ClassMap<IMDbMovie>
    {
        public MovieClassMap()
        {
            Map(m => m.IMDbTitleId).Name("imdb_title_id");
            Map(m => m.Title).Name("title");
            Map(m => m.OriginalTitle).Name("original_title");
            Map(m => m.Year).Convert(ParseYear);
            Map(m => m.DatePublished).Convert(ParseDatePublished);
            Map(m => m.Genres).Convert(args => ParseStringList(args, "genre"));
            Map(m => m.DurationInMinutes).Name("duration");
            Map(m => m.Country).Name("country");
            Map(m => m.Language).Name("language");
            Map(m => m.Director).Name("director");
            Map(m => m.Writer).Name("writer");
            Map(m => m.ProductionCompany).Name("production_company");
            Map(m => m.Actors).Convert(args => ParseStringList(args, "actors"));
            Map(m => m.Description).Name("description");
            Map(m => m.AverageVote).Name("avg_vote");
            Map(m => m.NumberOfVotes).Name("votes");
            Map(m => m.Budget).Name("budget");
            Map(m => m.GrossIncomeForUSA).Name("usa_gross_income");
            Map(m => m.WorldWideGrossIncome).Name("worlwide_gross_income");
            Map(m => m.MetaScore).Name("metascore");
            Map(m => m.UserReviewScores).Name("reviews_from_users");
            Map(m => m.CriticReviewScores).Name("reviews_from_critics");
        }

        private DateTime ParseDatePublished(ConvertFromStringArgs stringArgs)
        {
            var field = stringArgs.Row.GetField("date_published");
            
            if (DateTime.TryParse(field, out DateTime date))
            {
                return date;
            }

            if (int.TryParse(field, out int year))
            {
                return new DateTime(year);
            }

            var trimmedField = field.Replace("TV Movie ", string.Empty);
            return new DateTime(int.Parse(trimmedField));
        }

        private int ParseYear(ConvertFromStringArgs stringArgs)
        {
            var field = stringArgs.Row.GetField("year");

            if (int.TryParse(field, out int year))
            {
                return year;
            }

            var trimmedField = field.Replace("TV Movie ", string.Empty);
            return int.Parse(trimmedField);
        }

        private List<string> ParseStringList(ConvertFromStringArgs stringArgs, string fieldName)
        {
            var field = stringArgs.Row.GetField(fieldName);

            return field.Split(", ").ToList();
        }
    }
}
