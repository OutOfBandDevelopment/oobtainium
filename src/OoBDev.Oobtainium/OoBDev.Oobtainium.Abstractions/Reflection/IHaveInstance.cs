namespace OoBDev.Oobtainium.Reflection
{
    public interface IHaveInstance
    {
        object Instance { get; }
    }
    public interface IHaveInstance<T> : IHaveInstance
    {
        new T Instance { get; }
    }
}
