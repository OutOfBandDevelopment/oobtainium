using System;
using System.Reflection;

namespace OoBDev.Oobtainium;


public class BindingBuilder<S>(ICallBindingStore? store = null) : IBindingBuilder<S>
{
    public ICallBindingStore Store { get; } = store ?? new CallBindingStore();

    public IBindingBuilder<S> Bind(MethodInfo? method, Delegate? callback)
    {
        Store.Add(typeof(S), method, callback);
        return this;
    }

    public IBindingBuilder<U> Build<U>() => new BindingBuilder<U>(Store);
}
