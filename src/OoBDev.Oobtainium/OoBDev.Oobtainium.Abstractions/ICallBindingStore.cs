using System;
using System.Linq.Expressions;
using System.Reflection;

namespace OoBDev.Oobtainium
{
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
        void Remove(MethodInfo method);
        void Remove(Type? type);

        Delegate? this[MethodInfo method] { get; }
        Delegate? this[Type? type, MethodInfo method] { get; }
    }

}
