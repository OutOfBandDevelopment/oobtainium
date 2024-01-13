using OoBDev.Oobtainium.Recording;

namespace OoBDev.Oobtainium
{
    [ExcludeFromRecording]
    public interface IHaveCallBindingStore
    {
        ICallBindingStore Store { get; }
    }
}
