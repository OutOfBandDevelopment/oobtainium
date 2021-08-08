using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace OoBDev.Oobtainium
{
    public class CallBindingStore : ICallBindingStore, IToHandler
    {
        private readonly ConcurrentDictionary<(Type? type, MethodInfo method), Delegate> _store = new ConcurrentDictionary<(Type?, MethodInfo), Delegate>();

        //TODO: are these needed?  they can't do anything anyway
        public void Add(Expression action) => Add(action, null);
        public void Add<T>(Expression action) => Add<T>(action, null);
        public void Add(Type? type, Expression action) => Add(type, action, null);
        public void Add(Type? type, MethodInfo method) => Add(type, method, null);
        public void Add(MethodInfo method) => Add(null, method, null);

        public void Add<T>(Expression action, Delegate? callback) => Add(typeof(T), action, callback);
        public void Add(Expression action, Delegate? callback) => Add(null, action, callback);

        public void Add(Type? type, Expression action, Delegate? callback) => Add(type, action.AsMethodInfo(), callback);
        public void Add(MethodInfo method, Delegate? callback) => Add(method?.DeclaringType, method, callback);

        public void Add(Type? type, MethodInfo? method, Delegate? callback)
        {
            if (method == null || callback == null) return;
            _store.AddOrUpdate((type ?? method.DeclaringType, method), key => callback, (key, old) => callback);
        }

        public void Remove(Expression? action) => Remove(action?.AsMethodInfo());
        public void Remove(Type? type, Expression? action) => Remove(type, action?.AsMethodInfo());
        public void Remove(MethodInfo? method)
        {
            if (method == null) return;

            var selectedKeys = _store.Keys.Where(k => k.method == method).ToArray();
            foreach (var key in selectedKeys)
                _store.TryRemove(key, out _);
        }
        public void Remove(Type? type)
        {
            if (type == null) return;

            var selectedKeys = _store.Keys.Where(k => k.type == type).ToArray();
            foreach (var key in selectedKeys)
                _store.TryRemove(key, out _);
        }
        public void Remove(Type? type, MethodInfo? method)
        {
            if (method == null) return;

            var selectedKeys = _store.Keys.Where(k => k.type == type && k.method == method).ToArray();
            foreach (var key in selectedKeys)
                _store.TryRemove(key, out _);
        }

        public void Clear() => _store.Clear();

        public IReadOnlyList<(Type? type, MethodInfo method, Delegate callback)> GetAll() =>
            _store.Select(i => (i.Key.type, i.Key.method, i.Value)).ToArray();
        public IReadOnlyList<(MethodInfo method, Delegate callback)> GetByType(Type? type) =>
            (type == null || type == typeof(void)) ? Array.Empty<(MethodInfo, Delegate)>() :
            _store.Where(i => i.Key.type == type).Select(i => (i.Key.method, i.Value)).ToArray();

        public ICallHandler ToHandler() => new CallHandler(this);

        public Delegate? this[MethodInfo method] => this[null, method];
        public Delegate? this[Type? type, MethodInfo method] =>
            _store.TryGetValue((
                type ?? method?.DeclaringType,
                method ?? throw new NotSupportedException($"Unable to resolve {nameof(MethodInfo)}"
            )), out var @delegate) ? @delegate : null;
    }

}
