using Microsoft.Extensions.Logging;
using System;

namespace OoBDev.Oobtainium
{
    public class CaptureProxyFactory : ICaptureProxyFactory
    {
        private readonly IServiceProvider? _serviceProvider;
        public CaptureProxyFactory(IServiceProvider? serviceProvider = null) => _serviceProvider = serviceProvider;

        public T Create<T>(
            ICallHandler? handler = null,
            ICallRecorder? recorder = null,
            ILogger<T>? logger = null
            ) =>
            CaptureProxy<T>.Create(
                handler ?? _serviceProvider?.GetService(typeof(ICallHandler)) as ICallHandler ??
                    new CallHandler(_serviceProvider?.GetService(typeof(ICallBindingStore)) as ICallBindingStore),

                recorder ?? _serviceProvider?.GetService(typeof(ICallRecorder)) as ICallRecorder ??
                    new CallRecorder(_serviceProvider?.GetService(typeof(ILogger<ICallRecorder>)) as ILogger<ICallRecorder>),

                logger ?? _serviceProvider?.GetService(typeof(ILogger<T>)) as ILogger<T>
            );
    }
}
