using OoBDev.Oobtainium.Reflection;
using System.Reflection;

namespace OoBDev.Oobtainium.Recording
{
    public class CallRecorderProxy<T> : WrappedDispatchProxy<T>, INeedCallRecorder
    {
#pragma warning disable CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
        public ICallRecorder? Recorder { get; set; }
#pragma warning restore CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            var response = targetMethod.Invoke(this.Instance, args);
            if (targetMethod.AllowRecording())
                Recorder?.Capture?.Invoke(Instance, typeof(T), targetMethod, args, response);
            return response;
        }
    }
}
