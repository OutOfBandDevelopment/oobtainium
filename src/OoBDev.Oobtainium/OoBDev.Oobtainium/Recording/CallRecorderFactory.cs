using Microsoft.Extensions.Logging;
using System;

namespace OoBDev.Oobtainium.Recording
{
    public class CallRecorderFactory : ICallRecorderFactory
    {
        public readonly IServiceProvider? _serviceProvider;
        public CallRecorderFactory(IServiceProvider? serviceProvider = null) => _serviceProvider = serviceProvider;

        public ICallRecorder Create() =>
            _serviceProvider?.GetService(typeof(ICallRecorder)) as ICallRecorder ??
            new CallRecorder(_serviceProvider?.GetService(typeof(ILogger<ICallRecorder>)) as ILogger<ICallRecorder>)
            ;
    }
}
