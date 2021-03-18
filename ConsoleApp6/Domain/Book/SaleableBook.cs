using System;

namespace ConsoleApp6
{
    public class SaleableBook : BookBase, ISaleableProduct
    {
        public SaleableBook() : base() { }
        public SaleableBook(string name, long priceInCents) : base(name, priceInCents) { }

        public void ApplySale(long amountInCents)
        {
            var amountInCentsIsValid = amountInCents > MinimalPossiblePriceInCents && amountInCents <= PriceInCents;

            if (!amountInCentsIsValid)
            {
                throw new Exception();
            }

            PriceInCents -= amountInCents;
        }
    }
}
