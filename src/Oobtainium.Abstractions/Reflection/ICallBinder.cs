namespace OoBDev.Oobtainium.Reflection;

/// <summary>
/// Entry point for configuring service bindings. 
/// </summary>
public interface ICallBinder
{
    IBindingBuilder<T> Build<T>();
}
