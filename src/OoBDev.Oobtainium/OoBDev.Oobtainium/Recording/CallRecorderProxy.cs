using System;
using System.Reflection;

namespace OoBDev.Oobtainium.Recording
{
    public class CallRecorderProxy<T> : DispatchProxy, INeedCallRecorder<T>, IHaveCallRecorder
    {
        private T _instance;
        public ICallRecorder Recorder { get; set; }

        public void Capture(T instance)
        {
            if (_instance != null && ReferenceEquals(_instance, instance)) return;
            else if (_instance != null) throw new NotSupportedException("Instance already set");
            else _instance = instance ?? throw new ArgumentNullException($"Instance of type {instance} is required");
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            var response = targetMethod.Invoke(_instance, args);
            Recorder?.Capture(_instance, typeof(T), targetMethod, args, response);
            return response;
        }

        internal static T Create(
            T instance,
            ICallRecorder? capture = null
            )
        {
            object proxy = instance;
            if (proxy is INeedCallRecorder<T> need)
            {
                need.Recorder = capture ?? new CallRecorder();
            }
            else
            {
                var recorder = (INeedCallRecorder<T>)Create<T, CaptureProxy<T>>();
                recorder.Capture(instance);
                proxy = Create(instance, capture);
            }
            return (T)proxy;
        }

    }
}
