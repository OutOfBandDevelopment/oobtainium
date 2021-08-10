using OoBDev.Oobtainium.Recording;

namespace OoBDev.Oobtainium.Composition
{
    [ExcludeFromRecording]
    public interface IHaveCallBindingStore
    {
        ICallBindingStore Store { get; }
    }
}
