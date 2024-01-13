namespace OoBDev.Oobtainium.Reflection.Recording;

public interface ICallRecorderProxyFactory
{
    T AddRecorder<T>(T instance);
    T AttachRecorder<T>(T instance, ICallRecorder recorder);
}
