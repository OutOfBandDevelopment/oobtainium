namespace OoBDev.Oobtainium.Composition
{
    public static class CallBindingStoreExtensions
    {
        public static ICallBinder ToCallbinder(this ICallBindingStore store) => new CallBinder(store);
        public static IBindingBuilder<T> Build<T>(this ICallBindingStore store) => store.ToCallbinder().Build<T>();
        public static IBindingBuilder<T> Register<T>(this IHaveCallBindingStore have) => have.Store.Build<T>();

        //public static void Add(this ICallBindingStore store, Expression action) => store.Add(null, action.AsMethodInfo(), null);
        //public static void Add<T>(this ICallBindingStore store, Expression action) => store.Add(typeof(T), action.AsMethodInfo(), null);
        //public static void Add(this ICallBindingStore store, Type type, Expression action) => store.Add(type, action.AsMethodInfo(), null);
        //public static void Add(this ICallBindingStore store, Expression action, Delegate? callback) => store.Add(null, action.AsMethodInfo(), callback);
        //public static void Add<T>(this ICallBindingStore store, Expression action, Delegate? callback) => store.Add(typeof(T), action.AsMethodInfo(), callback);
        //public static void Add(this ICallBindingStore store, Type type, Expression action, Delegate? callback) => store.Add(type, action.AsMethodInfo(), callback);
        //public static void Add(this ICallBindingStore store, MethodInfo method) => store.Add(null, method, null);
        //public static void Add<T>(this ICallBindingStore store, MethodInfo method) => store.Add(typeof(T), method, null);
        //public static void Add(this ICallBindingStore store, Type type, MethodInfo method) => store.Add(type, method, null);
        //public static void Add(this ICallBindingStore store, MethodInfo method, Delegate? callback) => store.Add(null, method, callback);
        //public static void Add<T>(this ICallBindingStore store, MethodInfo method, Delegate? callback) => store.Add(typeof(T), method, callback);
        //public static void Add(this ICallBindingStore store, Type type, MethodInfo method, Delegate? callback) => store.Add(type, method, callback);
    }

}
