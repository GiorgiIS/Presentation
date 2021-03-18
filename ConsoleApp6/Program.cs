using System;
using System.Collections.Generic;

namespace GoodPractice
{
    public class Program
    {
        static void Main()
        {

            IBookFactory bookFactory = new BookFactory();

            var defaultBook = bookFactory.Default();
            var book = bookFactory.Create("The lord of the rings", 5000);

            defaultBook.ApplySale(1000); // Throws Error
            book.ApplySale(3000);
        }
    }

    public class Book : ISaleableProduct, ICanHaveDefaultValue
    {
        private readonly bool _isDefaultValue;

        private const long MinimalPossiblePriceInCents = 0;

        private const string DefaultName = "Default";

        public readonly string Name;

        public long PriceInCents { get; protected set; }

        public readonly ICollection<string> Authors = new List<string>();

        public Book()
        {
            _isDefaultValue = true;
            Name = DefaultName;
            PriceInCents = MinimalPossiblePriceInCents;
        }

        public Book(string name, long priceInCents)
        {
            if (string.IsNullOrEmpty(name) || priceInCents <= MinimalPossiblePriceInCents)
            {
                throw new Exception();
            }

            _isDefaultValue = false;
            Name = name;
            PriceInCents = priceInCents;
        }

        public void ApplySale(long amountInCents)
        {
            var amountInCentsIsValid = amountInCents > MinimalPossiblePriceInCents && amountInCents <= PriceInCents;

            if (!amountInCentsIsValid)
            {
                throw new Exception();
            }

            PriceInCents -= amountInCents;
        }

        public bool IsDefault() => _isDefaultValue;
    }

    public class BookFactory : IBookFactory
    {
        public Book Create(string name, long priceInCents) => new Book(name, priceInCents);
        public Book Default() => new Book();
    }

    public interface IBookFactory : IFactory<Book>
    {
        Book Create(string name, long priceInCents);
    }

    public interface IFactory<T> where T : ICanHaveDefaultValue
    {
        T Default();
    }

    public interface ISaleableProduct
    {
        void ApplySale(long amountInCents);
    }

    public interface ICanHaveDefaultValue
    {
        bool IsDefault();
    }
}