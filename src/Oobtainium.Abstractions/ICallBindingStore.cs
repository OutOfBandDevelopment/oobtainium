using OoBDev.Oobtainium.Recording;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace OoBDev.Oobtainium
{
    /// <summary>
    /// ICallBindingStore is used for configuring callback and interception bindings on the proxy classes
    /// </summary>
    [ExcludeFromRecording]
    public interface ICallBindingStore
    {
        void Add(Type? type, MethodInfo? method, Delegate? callback);

        void Clear();

        void Remove(MethodInfo method);
        void Remove(Type? type);
        void Remove(Type? type, MethodInfo? method);

        Delegate? this[MethodInfo method] { get; }
        Delegate? this[Type? type, MethodInfo method] { get; }

        IReadOnlyList<(Type? type, MethodInfo method, Delegate callback)> GetAll();
        IReadOnlyList<(MethodInfo method, Delegate callback)> GetByType(Type? type);
    }

}
