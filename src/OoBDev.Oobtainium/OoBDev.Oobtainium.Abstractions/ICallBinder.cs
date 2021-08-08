namespace OoBDev.Oobtainium
{
    public interface ICallBinder
    {
        IBindingBuilder<T> Register<T>();
    }
}
