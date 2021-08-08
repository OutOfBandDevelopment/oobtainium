namespace OoBDev.Oobtainium
{
    public class CallBinder : ICallBinder, IHaveCallBindingStore
    {
        public ICallBindingStore Store { get; }

        public CallBinder(ICallBindingStore? store = null) => Store = store ?? new CallBindingStore();

        public IBindingBuilder<T> Register<T>() => new BindingBuilder<T>(Store);
    }
}
