using System;
using System.Collections.Generic;

namespace BadPractice
{
    class Program
    {
        static void Main()
        {
            var book = new Book("The lord of the rings", 5000);

            book.ApplySale(3000);

            Console.WriteLine(book.Name);
        }
    }

    public class Book
    {
        public string Name { get; protected set; }

        public long PriceInCents { get; protected set; }

        public List<string> Authors { get; set; }

        public Book(string name, long priceInCents)
        {
            Name = name;
            PriceInCents = priceInCents;
        }

        public void ApplySale(long amount)
        {
            PriceInCents -= amount;
        }
    }
}