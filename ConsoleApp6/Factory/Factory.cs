namespace ConsoleApp6
{
    public class Factory<T> : IFactory<T> where T : ICanHaveDefaultValue, new()
    {
        public T Default()
        {
           return new T();
        }
    }
}
