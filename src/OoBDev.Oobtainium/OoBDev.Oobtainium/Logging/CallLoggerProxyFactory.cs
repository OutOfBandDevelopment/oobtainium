using Microsoft.Extensions.Logging;
using OoBDev.Oobtainium.Composition;
using OoBDev.Oobtainium.Recording;
using OoBDev.Oobtainium.Reflection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OoBDev.Oobtainium.Logging
{
    public class CallLoggerProxyFactory : ICallLoggerProxyFactory
    {
        private readonly IServiceProvider? _serviceProvider;
        public CallLoggerProxyFactory(IServiceProvider? serviceProvider = null) => _serviceProvider = serviceProvider;


        public T AddLogger<T>(T instance)
        {
            throw new NotImplementedException();
        }

        public T AttachLogger<T>(T instance, ILogger? logger = null) =>
            throw new NotImplementedException();


        //public T AddRecorder<T>(T instance) => instance.AddRecorder(_factory);
        //public T AttachRecorder<T>(T instance, ICallRecorder recorder) => instance.AddRecorder(recorder);

        //internal static T InternalAddLogger<T>(
        //    T instance,
        //    ILogger? logger = null
        //    ) =>
        //    AttachLogger(
        //        instance,
        //        logger
        //    );

        //internal static T InternalAddLogger<T>(
        //    T instance,
        //    ILogger? logger = null
        //    )
        //{
        //    if (instance == null) throw new ArgumentNullException(nameof(instance));
        //    if (instance is INeedCallLogger need)
        //    {
        //        log?.LogDebug($"Adding logger to {instance}");
        //        //Is class is already support call recording then just update the recorder
        //        need.Logger = logger;
        //        return instance;
        //    }
        //    else if (instance is IHaveCallRecorder)
        //    {
        //        log?.LogDebug($"Call recorder already attached to {instance}");
        //        // if already has a recorder by 
        //        return instance;
        //    }
        //    else
        //    {
        //        log?.LogDebug($"Creating proxy of {instance}");
        //        var extended = instance.AddInterface<T, CallRecorderProxy<T>>();
        //        var proxy = AttachLogger(extended, logger);
        //        return proxy;
        //    }
        //}
    }

    //public static class ObjectExtensions
    //{
    //    public static T AddLogger<T>(this T instance) =>
    //        CallLoggerProxyFactory.InternalAddLogger(instance);

    //    public static T AddRecorAddLoggerder<T>(this T instance, ICallRecorder recorder) =>
    //        CallLoggerProxyFactory.InternalAddLogger(instance, recorder: recorder ?? throw new ArgumentNullException(nameof(recorder)));

    //    public static T AddLogger<T>(this T instance, ICallRecorderFactory factory) =>
    //        CallLoggerProxyFactory.InternalAddLogger(instance, factory: factory ?? throw new ArgumentNullException(nameof(factory)));

    //    public static bool TryGetRecorder<T>(this T instance, out ICallRecorder? recorder)
    //    {
    //        if (instance is IHaveCallRecorder have)
    //        {
    //            recorder = have.Recorder;
    //            return true;
    //        }

    //        recorder = default;
    //        return false;
    //    }

    //    internal static bool AllowRecording(this MethodInfo method) => method switch
    //    {
    //        null => false,
    //        _ when method.HasAttribute<ExcludeFromRecordingAttribute>() => false,
    //        _ when method.DeclaringType?.HasAttribute<ExcludeFromRecordingAttribute>() ?? false => false,
    //        _ => true
    //    };
    //}

    internal interface INeedCallLogger : IHaveCallLogger
    {
        new ILogger Logger { set; }
    }

    public class CallLoggerProxy<T> : WrappedDispatchProxy<T>, INeedCallLogger
    {
        public ILogger Logger { get; set; }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            try
            {
                Logger.LogDebug($"Enter: {this.Instance}::{targetMethod}");
                var ret = targetMethod.Invoke(this.Instance, args);

                if (ret is Task task)
                {
                }
                Logger.LogInformation($"Finish: {this.Instance}::{targetMethod}");

                Logger.LogTrace($"Return: {this.Instance}::{targetMethod} => {ret}");
                return ret;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                Logger.LogDebug(ex.ToString());
                throw;
            }
            finally
            {
                Logger.LogDebug($"Exit: {this.Instance}::{targetMethod}");
            }
        }
    }
}
