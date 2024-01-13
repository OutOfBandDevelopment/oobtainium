namespace OoBDev.Oobtainium.Reflection.Recording;

[ExcludeFromRecording]
public interface IHaveCallRecorder
{
    ICallRecorder Recorder { get; }
}
