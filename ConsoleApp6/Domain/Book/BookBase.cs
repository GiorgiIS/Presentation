using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    public abstract class BookBase : ICanHaveDefaultValue
    {
        private readonly bool _isDefaultValue;

        protected const long MinimalPossiblePriceInCents = 0;

        private const string DefaultName = "Default";

        public readonly string Name;

        public long PriceInCents { get; protected set; }

        public readonly ICollection<string> Authors = new List<string>();

        public BookBase()
        {
            _isDefaultValue = true;
            Name = DefaultName;
            PriceInCents = MinimalPossiblePriceInCents;
        }

        public BookBase(string name, long priceInCents)
        {
            if (string.IsNullOrEmpty(name) || priceInCents <= MinimalPossiblePriceInCents)
            {
                throw new Exception();
            }

            _isDefaultValue = false;
            Name = name;
            PriceInCents = priceInCents;
        }

        public bool IsDefault() => _isDefaultValue;
    }
}
