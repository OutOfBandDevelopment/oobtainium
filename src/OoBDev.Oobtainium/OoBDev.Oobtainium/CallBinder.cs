namespace OoBDev.Oobtainium;

public class CallBinder(ICallBindingStore? store = null) : ICallBinder, IHaveCallBindingStore
{
    public ICallBindingStore Store { get; } = store ?? new CallBindingStore();

    public IBindingBuilder<T> Build<T>() => new BindingBuilder<T>(Store);
}
