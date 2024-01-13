using System.Reflection;

namespace OoBDev.Oobtainium.Reflection
{
    public abstract class WrappedDispatchProxy : DispatchProxy, INeedInstance
    {
        public object Instance { get; set; }
    }
    public abstract class WrappedDispatchProxy<T> : WrappedDispatchProxy
    {
    }
}
