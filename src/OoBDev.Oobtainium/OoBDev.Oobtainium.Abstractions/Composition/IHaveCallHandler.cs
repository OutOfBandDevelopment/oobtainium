using OoBDev.Oobtainium.Recording;

namespace OoBDev.Oobtainium.Composition
{
    [ExcludeFromRecording]
    public interface IHaveCallHandler
    {
        ICallHandler Handler { get; }
    }
}
