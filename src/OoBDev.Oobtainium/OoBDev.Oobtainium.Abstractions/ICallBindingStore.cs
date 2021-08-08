using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace OoBDev.Oobtainium
{
    /// <summary>
    /// ICallBindingStore is used for configuring callback and interception bindings on the proxy classes
    /// </summary>
    public interface ICallBindingStore
    {
        void Add(Expression action);
        void Add(Expression action, Delegate? callback);
        void Add<T>(Expression action);
        void Add<T>(Expression action, Delegate? callback);
        void Add(Type? type, Expression action);
        void Add(Type? type, Expression action, Delegate? callback);
        void Add(Type? type, MethodInfo method);
        void Add(Type? type, MethodInfo method, Delegate? callback);
        void Add(MethodInfo method);
        void Add(MethodInfo method, Delegate? callback);

        void Clear();

        void Remove(Expression action);
        void Remove(Type? type, Expression? action);
        void Remove(MethodInfo method);
        void Remove(Type? type);
        void Remove(Type? type, MethodInfo? method);

        Delegate? this[MethodInfo method] { get; }
        Delegate? this[Type? type, MethodInfo method] { get; }

        IReadOnlyList<(Type? type, MethodInfo method, Delegate callback)> GetAll();
        IReadOnlyList<(MethodInfo method, Delegate callback)> GetByType(Type? type);
    }

}
