namespace ConsoleApp6
{
    public interface IFactory<T> where T : ICanHaveDefaultValue, new()
    {
        T Default();
    }
}
