using System.Reflection;
using System;

namespace OoBDev.Oobtainium
{
    public interface IBindingBuilder<S> : IHaveCallBindingStore
    {
        IBindingBuilder<S> Bind(MethodInfo? method, Delegate? callback);

        /// <summary>
        /// Chain additional interface
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        IBindingBuilder<U> Register<U>();
    }
}
