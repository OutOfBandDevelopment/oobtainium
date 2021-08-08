using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace OoBDev.Oobtainium
{
    public static class BindingBuilderExtensions
    {
        public static IBindingBuilder<S> Bind<S>(this IBindingBuilder<S> builder, Expression<Action<S>> action, Action callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Action<S>> action, Func<R> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S>(this IBindingBuilder<S> builder, Expression<Action<S>> action, Func<Task> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Action<S>> action, Func<Task<R>> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S>(this IBindingBuilder<S> builder, Expression<Action<S>> action, Action<object?[]> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Action<S>> action, Func<object?[], R> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S>(this IBindingBuilder<S> builder, Expression<Action<S>> action, Func<object?[], Task> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Action<S>> action, Func<object?[], Task<R>> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, R>> action, Action callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, R>> action, Func<R> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, R>> action, Func<Task> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, R>> action, Func<Task<R>> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, R>> action, Action<object?[]> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, R>> action, Func<object?[], R> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, R>> action, Func<object?[], Task> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, R>> action, Func<object?[], Task<R>> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S>(this IBindingBuilder<S> builder, Expression<Func<S, Task>> action, Action callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, Task>> action, Func<R> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S>(this IBindingBuilder<S> builder, Expression<Func<S, Task>> action, Func<Task> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, Task>> action, Func<Task<R>> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S>(this IBindingBuilder<S> builder, Expression<Func<S, Task>> action, Action<object?[]> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, Task>> action, Func<object?[], R> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S>(this IBindingBuilder<S> builder, Expression<Func<S, Task>> action, Func<object?[], Task> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, Task>> action, Func<object?[], Task<R>> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, Task<R>>> action, Action callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, Task<R>>> action, Func<R> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, Task<R>>> action, Func<Task> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, Task<R>>> action, Func<Task<R>> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, Task<R>>> action, Action<object?[]> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, Task<R>>> action, Func<object?[], R> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, Task<R>>> action, Func<object?[], Task> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R>(this IBindingBuilder<S> builder, Expression<Func<S, Task<R>>> action, Func<object?[], Task<R>> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R, Q>(this IBindingBuilder<S> builder, Expression<Func<S, R>> action, Func<Q> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R, Q>(this IBindingBuilder<S> builder, Expression<Func<S, R>> action, Func<Task<Q>> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R, Q>(this IBindingBuilder<S> builder, Expression<Func<S, R>> action, Func<object?[], Q> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R, Q>(this IBindingBuilder<S> builder, Expression<Func<S, R>> action, Func<object?[], Task<Q>> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R, Q>(this IBindingBuilder<S> builder, Expression<Func<S, Task<R>>> action, Func<Q> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R, Q>(this IBindingBuilder<S> builder, Expression<Func<S, Task<R>>> action, Func<Task<Q>> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R, Q>(this IBindingBuilder<S> builder, Expression<Func<S, Task<R>>> action, Func<object?[], Q> callback) => builder.Bind(action.AsMethodInfo(), callback);
        //public static IBindingBuilder<S> Bind<S, R, Q>(this IBindingBuilder<S> builder, Expression<Func<S, Task<R>>> action, Func<object?[], Task<Q>> callback) => builder.Bind(action.AsMethodInfo(), callback);
    }

    public class BindingBuilder<S> : IBindingBuilder<S>
    {
        public BindingBuilder(ICallBindingStore? store = null) => Store = store ?? new CallBindingStore();

        public ICallBindingStore Store { get; }

        public IBindingBuilder<S> Bind(MethodInfo? method, Delegate? callback)
        {
            Store.Add(typeof(S), method, callback);
            return this;
        }

        public IBindingBuilder<U> Register<U>() => new BindingBuilder<U>(Store);
    }

}
