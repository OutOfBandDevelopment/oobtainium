using Microsoft.Extensions.Logging;
using System;

namespace OoBDev.Oobtainium.Recording
{
    public class CallRecorderProxyFactory
    {
        public static T WithRecorder<T>(
            T instance,
            ICallRecorder? recorder = null,
            IServiceProvider? serviceProvider = null
            ) =>
            CallRecorderProxy<T>.Create(
                instance,
                recorder ?? serviceProvider?.GetService(typeof(ICallRecorder)) as ICallRecorder ??
                    new CallRecorder(serviceProvider?.GetService(typeof(ILogger<ICallRecorder>)) as ILogger<ICallRecorder>)
            );
    }
}
