using Microsoft.Extensions.Logging;
using OoBDev.Oobtainium.Recording;
using System;

namespace OoBDev.Oobtainium;

public class CaptureProxyFactory : ICaptureProxyFactory
{
    private readonly IServiceProvider? _serviceProvider;
    public CaptureProxyFactory(IServiceProvider? serviceProvider = null) => _serviceProvider = serviceProvider;

    public T Create<T>(
        ICallHandler? handler = null,
        ILogger<T>? logger = null
        ) =>
        CaptureProxy<T>.Create(
            handler ?? _serviceProvider?.GetService(typeof(ICallHandler)) as ICallHandler ??
                new CallHandler(_serviceProvider?.GetService(typeof(ICallBindingStore)) as ICallBindingStore),
            logger ?? _serviceProvider?.GetService(typeof(ILogger<T>)) as ILogger<T>
        );

    public T CreateWithRecorder<T>(
        ICallRecorder? recorder = null,
        ICallHandler? handler = null,
        ILogger<T>? logger = null
        ) => Create(handler, logger).AddRecorder(recorder ?? new CallRecorderFactory(_serviceProvider).Create())
        ;
}
