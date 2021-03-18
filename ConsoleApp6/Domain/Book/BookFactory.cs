using System;

namespace ConsoleApp6
{
    public class BookFactory<T> : Factory<T>, IBookFactory<T> where T : BookBase, new()
    {
        public T Create(string name, long priceInCents) => (T)Activator.CreateInstance(typeof(T), name, priceInCents);
    }
}
