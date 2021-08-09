using OoBDev.Oobtainium.Reflection;
using System.Reflection;

namespace OoBDev.Oobtainium.Recording
{
    public class CallRecorderProxy<T> : WrappedDispatchProxy<T>, INeedCallRecorder
    {
        public ICallRecorder? Recorder { get; set; }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            var response = targetMethod.Invoke(this.Instance, args);
            Recorder?.Capture(Instance, typeof(T), targetMethod, args, response);
            return response;
        }
    }
}
