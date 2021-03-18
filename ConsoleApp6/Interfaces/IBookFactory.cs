namespace ConsoleApp6
{
    public interface IBookFactory<T> : IFactory<T> where T : BookBase, new()
    {
        T Create(string name, long priceInCents);
    }
}
