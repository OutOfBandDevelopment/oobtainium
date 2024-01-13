namespace OoBDev.Oobtainium.Recording;

internal interface INeedCallRecorder : IHaveCallRecorder
{
    new ICallRecorder Recorder { set; }
}
