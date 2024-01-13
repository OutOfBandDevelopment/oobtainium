namespace OoBDev.Oobtainium
{
    public static class CallHandlerExtensions
    {
        public static IBindingBuilder<T> Register<T>(this ICallHandler handler) => handler.Store.Build<T>();
        public static IBindingBuilder<T> Register<T>(this IHaveCallHandler have) => have.Handler.Register<T>();

    }

}
