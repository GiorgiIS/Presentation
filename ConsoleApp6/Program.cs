using System;

namespace ConsoleApp6
{
    public class Program
    {
        static void Main()
        {
            IBookFactory<SaleableBook> salebleBookFactory = new BookFactory<SaleableBook>();
            var saleableBook = salebleBookFactory.Create("The lord of the rings", 5000);
            saleableBook.ApplySale(3000);

            Console.WriteLine(saleableBook .PriceInCents);

            //////////////////////////////////////////////////////////////////////////////////

            IBookFactory<Book> bookFactory = new BookFactory<Book>();
            var book = bookFactory.Create("The lord of the rings", 5000);

            Console.WriteLine(book.PriceInCents);
        }
    }
}