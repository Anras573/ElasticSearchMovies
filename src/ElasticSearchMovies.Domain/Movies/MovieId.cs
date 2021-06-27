namespace ElasticSearchMovies.Domain.Movies
{
    public struct MovieId
    {
        public string Value { get; }

        private MovieId(string id)
        {
            Value = id;
        }

        public static MovieId Create(string id)
        {
            return new MovieId(id);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
