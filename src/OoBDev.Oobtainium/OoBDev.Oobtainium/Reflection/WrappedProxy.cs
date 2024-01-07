using System.Reflection;

namespace OoBDev.Oobtainium.Reflection;

public abstract class WrappedDispatchProxy : DispatchProxy, INeedInstance
{
    public required object Instance { get; set; }
}
public abstract class WrappedDispatchProxy<T> : WrappedDispatchProxy
{
}
