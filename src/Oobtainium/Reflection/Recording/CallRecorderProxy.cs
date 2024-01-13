using OoBDev.Oobtainium.Reflection;
using OoBDev.Oobtainium.Reflection.Recording;
using System.Reflection;

namespace OoBDev.Oobtainium.Reflection.Recording;

public class CallRecorderProxy<T> : WrappedDispatchProxy<T>, INeedCallRecorder
{
    public ICallRecorder? Recorder { get; set; }

    protected override object Invoke(MethodInfo targetMethod, object[] args)
    {
        var response = targetMethod.Invoke(Instance, args);
        if (targetMethod.AllowRecording())
        {
            Recorder?.Capture(Instance, typeof(T), targetMethod, args, response);
        }

        return response;
    }
}
