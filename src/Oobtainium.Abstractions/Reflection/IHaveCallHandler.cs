using OoBDev.Oobtainium.Reflection.Recording;

namespace OoBDev.Oobtainium.Reflection;

[ExcludeFromRecording]
public interface IHaveCallHandler
{
    ICallHandler Handler { get; }
}
