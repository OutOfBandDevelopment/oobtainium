using OoBDev.Oobtainium.Reflection.Recording;

namespace OoBDev.Oobtainium.Reflection;

[ExcludeFromRecording]
public interface IHaveCallBindingStore
{
    ICallBindingStore Store { get; }
}
