using OoBDev.Oobtainium.Reflection.Recording;

namespace OoBDev.Oobtainium.Reflection.Recording;

internal interface INeedCallRecorder : IHaveCallRecorder
{
    new ICallRecorder Recorder { set; }
}
