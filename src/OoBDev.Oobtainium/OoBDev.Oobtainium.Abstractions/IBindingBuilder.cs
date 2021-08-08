using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OoBDev.Oobtainium
{
    public interface IBindingBuilder<S>
    {
        IBindingBuilder<S> Bind(Expression<Action<S>> action, Action callback);
        IBindingBuilder<S> Bind(Expression<Action<S>> action, Action<object[]> callback);

        IBindingBuilder<S> Bind(Expression<Action<S>> action, Func<Task> callback);
        IBindingBuilder<S> Bind(Expression<Action<S>> action, Func<object[], Task> callback);

        IBindingBuilder<S> Bind(Expression<Action<S>> action);
        IBindingBuilder<S> Bind(Expression<Func<S, Task>> action);

        IBindingBuilder<S> Bind<R>(Expression<Func<S, R>> action, Func<object[], R>? callback);
        IBindingBuilder<S> Bind<R>(Expression<Func<S, Task<R>>> action, Func<object[], R>? callback);
        IBindingBuilder<S> Bind<R>(Expression<Func<S, R>> action, Func<R>? callback);
        IBindingBuilder<S> Bind<R>(Expression<Func<S, Task<R>>> action, Func<R>? callback);

        IBindingBuilder<U> Register<U>();
        ICallBindingStore Store { get; }
    }
}
