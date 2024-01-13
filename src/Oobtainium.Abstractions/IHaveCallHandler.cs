using OoBDev.Oobtainium.Recording;

namespace OoBDev.Oobtainium
{
    [ExcludeFromRecording]
    public interface IHaveCallHandler
    {
        ICallHandler Handler { get; }
    }
}
