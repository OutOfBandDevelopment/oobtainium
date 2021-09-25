using Microsoft.Extensions.Logging;

namespace OoBDev.Oobtainium.Logging
{
    public interface ICallLoggerProxyFactory
    {
        T AddLogger<T>(T instance);
        T AttachLogger<T>(T instance, ILogger logger);
    }
}
