using Microsoft.Extensions.DependencyInjection;

namespace OoBDev.Oobtainium
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// This will configuration your IOC container to support Oobtainium.  ICallRecoder and ICallBindingStore are "Scoped" by default
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddOobtainium(this IServiceCollection services) => services
                .AddScoped<ICallRecorder, CallRecorder>()
                .AddScoped<ICallBindingStore, CallBindingStore>()

                .AddTransient<ICaptureProxyFactory, CaptureProxyFactory>()
                .AddTransient<ICallBinder, CallBinder>()
                .AddTransient<ICallHandler, CallHandler>()
            ;
    }
}
