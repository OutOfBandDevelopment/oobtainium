using System;
using System.Linq.Expressions;
using System.Reflection;

namespace OoBDev.Oobtainium.Composition
{
    /// <summary>
    /// Call handler allows for calling operations within the ICallBindingStore
    /// </summary>
    public interface ICallHandler : IHaveCallBindingStore
    {
        object? Invoke<T>(MethodInfo method, object[]? arguments);
        object? Invoke<T>(MethodInfo method);
        object? Invoke(Type? type, MethodInfo method, object[]? arguments);
        object? Invoke(Type? type, MethodInfo method);
        object? Invoke(MethodInfo method, object[]? arguments);
        object? Invoke(MethodInfo method);
        object? Invoke(Type? type, Expression action);
        object? Invoke(Expression action);
        object? Invoke<T>(Expression action);
        object? Invoke(Type? type, Expression action, object[]? arguments);
        object? Invoke(Expression action, object[]? arguments);
        object? Invoke<T>(Expression action, object[]? arguments);
    }
}
