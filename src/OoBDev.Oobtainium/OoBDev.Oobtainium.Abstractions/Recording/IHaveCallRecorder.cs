namespace OoBDev.Oobtainium.Recording;

[ExcludeFromRecording]
public interface IHaveCallRecorder
{
    ICallRecorder? Recorder { get; }
}
