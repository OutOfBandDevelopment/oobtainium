using Microsoft.Extensions.DependencyInjection;
using OoBDev.Oobtainium.Reflection.Recording;
using OoBDev.Oobtainium.Reflection;

namespace OoBDev.Oobtainium;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// This will configuration your IOC container to support Oobtainium.  ICallRecoder and ICallBindingStore are "Scoped" by default
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddOobtainium(this IServiceCollection services) => services
            .AddScoped<ICallRecorder, CallRecorder>()

            .AddTransient<ICallRecorderFactory, CallRecorderFactory>()
            .AddTransient<ICallRecorderProxyFactory, CallRecorderProxyFactory>()

            .AddTransient<ICaptureProxyFactory, CaptureProxyFactory>()
            .AddTransient<ICallBinder, CallBinder>()
            .AddTransient<ICallHandler, CallHandler>()
        ;
    //TODO: create a container configuration class to allow for controlling the scope of the recorder and defaulting if to include it on call handler or not
}