using Microsoft.Extensions.Logging;
using System;

namespace OoBDev.Oobtainium.Recording;

public class CallRecorderFactory(IServiceProvider? serviceProvider = null) : ICallRecorderFactory
{
    public readonly IServiceProvider? _serviceProvider = serviceProvider;

    public ICallRecorder Create() =>
        _serviceProvider?.GetService(typeof(ICallRecorder)) as ICallRecorder ??
        new CallRecorder(_serviceProvider?.GetService(typeof(ILogger<ICallRecorder>)) as ILogger<ICallRecorder>)
        ;
}
