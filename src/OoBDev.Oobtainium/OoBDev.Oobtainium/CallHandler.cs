using System;
using System.Linq.Expressions;
using System.Reflection;

namespace OoBDev.Oobtainium
{
    public class CallHandler : ICallHandler
    {
        private readonly ICallBindingStore _store;

        public CallHandler(ICallBindingStore store) => _store = store;

        private object? Invocation(Type? type, MethodInfo method, object[]? arguments)
        {
            var @delegate = _store[type, method];
            if (@delegate == null) return null;

            var parameters = @delegate.Method.GetParameters();

            var requestArguments = parameters.Length switch
            {
                0 => Array.Empty<object>(),
                1 when parameters[0].ParameterType == typeof(object[]) => new object[] { arguments ?? Array.Empty<object>() },
                _ when parameters.Length == (arguments?.Length ?? 0) => arguments,
                _ => BuildDelegateArguments(parameters, arguments)
            };

            var result = @delegate.DynamicInvoke(requestArguments);
            return method.ReturnType.ConvertOrDefault(result);
        }

        private object?[] BuildDelegateArguments(ParameterInfo[] parameters, object[]? arguments)
        {
            var args = new object?[parameters.Length];
            var argLength = arguments?.Length ?? 0;
            for (var index = 0; index < parameters.Length; index++)
            {
                if (index < argLength && parameters[index].ParameterType.IsInstanceOfType(arguments[index]))
                {
                    args[index] = arguments[index];
                }
                else
                {
                    args[index] = parameters[index].ParameterType?.GetDefaultValue();
                }
            }
            return args;
        }

        public object? Invoke(Type? type, MethodInfo method) => Invocation(type, method, null);
        public object? Invoke(Type? type, MethodInfo method, object[]? arguments) => Invocation(type, method, arguments);
        public object? Invoke<T>(MethodInfo method) => Invocation(null, method, null);

        public object? Invoke(MethodInfo method) => Invocation(null, method, null);
        public object? Invoke(MethodInfo method, object[]? arguments) => Invocation(null, method, arguments);
        public object? Invoke<T>(MethodInfo method, object[]? arguments) => Invocation(typeof(T), method, arguments);

        public object? Invoke(Expression action) => Invocation(null, action.AsMethodInfo(), null);
        public object? Invoke(Type? type, Expression action) => Invocation(type, action.AsMethodInfo(), null);
        public object? Invoke<T>(Expression action) => Invocation(typeof(T), action.AsMethodInfo(), null);

        public object? Invoke(Type? type, Expression action, object[]? arguments) => Invocation(type, action.AsMethodInfo(), arguments);
        public object? Invoke(Expression action, object[]? arguments) => Invocation(null, action.AsMethodInfo(), arguments);
        public object? Invoke<T>(Expression action, object[]? arguments) => Invocation(typeof(T), action.AsMethodInfo(), arguments);
    }

}
