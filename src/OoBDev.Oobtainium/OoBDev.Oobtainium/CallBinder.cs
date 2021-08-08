namespace OoBDev.Oobtainium
{
    public class CallBinder : ICallBinder, IToHandler
    {
        private readonly ICallBindingStore _store;
        public CallBinder(ICallBindingStore? store = null) => _store = store ?? new CallBindingStore();

        public IBindingBuilder<T> Register<T>() => new BindingBuilder<T>(_store);

        public ICallHandler ToHandler() => new CallHandler(_store);
    }
}
