using System.Reflection;

namespace OoBDev.Oobtainium.Reflection
{
    public abstract class WrappedDispatchProxy : DispatchProxy, INeedInstance
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public object Instance { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
    public abstract class WrappedDispatchProxy<T> : WrappedDispatchProxy
    {
    }
}
