using OoBDev.Oobtainium.Recording;

namespace OoBDev.Oobtainium.Reflection
{

    [ExcludeFromRecording]
    public interface IHaveInstance
    {
        object Instance { get; }
    }
    public interface IHaveInstance<T> : IHaveInstance
    {
        new T Instance { get; }
    }
}
