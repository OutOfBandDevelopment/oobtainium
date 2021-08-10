using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OoBDev.Oobtainium.Composition
{
    public class CallBindingStore : ICallBindingStore
    {
        private readonly ConcurrentDictionary<(Type? type, MethodInfo method), Delegate> _store = new ConcurrentDictionary<(Type?, MethodInfo), Delegate>();

        public void Add(Type? type, MethodInfo? method, Delegate? callback)
        {
            if (method == null || callback == null) return;
            _store.AddOrUpdate((type ?? method.DeclaringType, method), key => callback, (key, old) => callback);
        }

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
            _store.TryRemove((type, method), out _);
        }

        public void Clear() => _store.Clear();

        public IReadOnlyList<(Type? type, MethodInfo method, Delegate callback)> GetAll() =>
            _store.Select(i => (i.Key.type, i.Key.method, i.Value)).ToArray();
        public IReadOnlyList<(MethodInfo method, Delegate callback)> GetByType(Type? type) =>
            (type == null || type == typeof(void)) ? Array.Empty<(MethodInfo, Delegate)>() :
            _store.Where(i => i.Key.type == type).Select(i => (i.Key.method, i.Value)).ToArray();

        public Delegate? this[MethodInfo method] => this[null, method];
        public Delegate? this[Type? type, MethodInfo method] =>
            _store.TryGetValue((
                type ?? method?.DeclaringType,
                method ?? throw new NotSupportedException($"Unable to resolve {nameof(MethodInfo)}"
            )), out var @delegate) ? @delegate : null;
    }

}
