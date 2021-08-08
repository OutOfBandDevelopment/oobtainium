using Microsoft.Extensions.Logging;

namespace OoBDev.Oobtainium
{
    public interface ICaptureProxyFactory
    {
        T Create<T>(ICallRecorder? Recorder = null, ICallHandler? handler = null, ILogger<T>? logger = null);
    }
}