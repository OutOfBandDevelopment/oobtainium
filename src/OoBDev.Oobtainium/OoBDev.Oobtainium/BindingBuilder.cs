using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OoBDev.Oobtainium
{
    public class BindingBuilder<S> : IBindingBuilder<S>
    {
        public BindingBuilder(ICallBindingStore? store = null) => Store = store ?? new CallBindingStore();

        public ICallBindingStore Store { get; }

        protected virtual IBindingBuilder<S> AddBinding(Expression action, Delegate? callback)
        {
            Store.Add<S>(action, callback);
            return this;
        }

        public IBindingBuilder<S> Bind(Expression<Action<S>> action, Action callback) => AddBinding(action, callback);
        public IBindingBuilder<S> Bind(Expression<Action<S>> action, Action<object[]> callback) => AddBinding(action, callback);
        public IBindingBuilder<S> Bind(Expression<Action<S>> action) => AddBinding(action, null);
        public IBindingBuilder<S> Bind(Expression<Func<S, Task>> action) => AddBinding(action, null);
        public IBindingBuilder<S> Bind<R>(Expression<Func<S, R>> action, Func<object[], R>? callback) => AddBinding(action, callback);
        public IBindingBuilder<S> Bind<R>(Expression<Func<S, Task<R>>> action, Func<object[], R>? callback) => AddBinding(action, callback);
        public IBindingBuilder<S> Bind<R>(Expression<Func<S, R>> action, Func<R>? callback) => AddBinding(action, callback);
        public IBindingBuilder<S> Bind<R>(Expression<Func<S, Task<R>>> action, Func<R>? callback) => AddBinding(action, callback);
        public IBindingBuilder<S> Bind(Expression<Action<S>> action, Func<Task> callback) => AddBinding(action, callback);
        public IBindingBuilder<S> Bind(Expression<Action<S>> action, Func<object[], Task> callback) => AddBinding(action, callback);

        public IBindingBuilder<U> Register<U>() => new CallBinder(Store).Register<U>();
    }

}
