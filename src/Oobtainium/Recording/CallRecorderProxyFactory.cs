using Microsoft.Extensions.Logging;
using OoBDev.Oobtainium.Reflection;
using System;

namespace OoBDev.Oobtainium.Recording;

public class CallRecorderProxyFactory : ICallRecorderProxyFactory
{
    public readonly ICallRecorderFactory _factory;

    public CallRecorderProxyFactory(ICallRecorderFactory? factory = null) => _factory = factory ?? new CallRecorderFactory();

    public T AddRecorder<T>(T instance) => instance.AddRecorder(_factory);
    public T AttachRecorder<T>(T instance, ICallRecorder recorder) => instance.AddRecorder(recorder);

    internal static T InternalAddRecorder<T>(
        T instance,
        ICallRecorder? recorder = null,
        ICallRecorderFactory? factory = null
        ) =>
        AttachRecorder(
            instance,
            recorder ?? (factory ?? new CallRecorderFactory()).Create()
        );

    internal static T AttachRecorder<T>(
        T instance,
        ICallRecorder? capture = null,
        ILogger<T>? log = null
        )
    {
        if (instance == null) throw new ArgumentNullException(nameof(instance));
        if (instance is INeedCallRecorder need)
        {
            log?.LogDebug($"Adding recorder to {instance}");
            //Is class is already support call recording then just update the recorder
            need.Recorder = capture ?? new CallRecorder();
            return instance;
        }
        else if (instance is IHaveCallRecorder)
        {
            log?.LogDebug($"Call recorder already attached to {instance}");
            // if already has a recorder by 
            return instance;
        }
        else
        {
            log?.LogDebug($"Creating proxy of {instance}");
            var extended = instance.AddInterface<T, CallRecorderProxy<T>>();
            var proxy = AttachRecorder(extended, capture);
            return proxy;
        }
    }
}
