namespace ElasticSearchMovies.Domain.Movies
{
    public struct ExternalId
    {
        public string Value { get; }

        private ExternalId(string id)
        {
            Value = id;
        }

        public static ExternalId Create(string id)
        {
            return new ExternalId(id);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
