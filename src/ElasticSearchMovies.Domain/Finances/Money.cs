namespace ElasticSearchMovies.Domain.Finances
{
    public struct Money
    {
        public Currency Currency { get; }
        public decimal Value { get; }

        private Money(Currency currency, decimal value)
        {
            Currency = currency;
            Value = value;
        }

        public static Money Create(Currency currency, decimal value)
        {
            return new Money(currency, value);
        }

        public override string ToString()
        {
            return $"{Value} {Currency}";
        }
    }
}
