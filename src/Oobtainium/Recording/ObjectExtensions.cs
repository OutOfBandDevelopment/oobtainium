using OoBDev.Oobtainium.ComponentModel;
using System;
using System.Reflection;

namespace OoBDev.Oobtainium.Recording;

public static class ObjectExtensions
{
    public static T AddRecorder<T>(this T instance) =>
        CallRecorderProxyFactory.InternalAddRecorder(instance);

    public static T AddRecorder<T>(this T instance, ICallRecorder recorder) =>
        CallRecorderProxyFactory.InternalAddRecorder(instance, recorder: recorder ?? throw new ArgumentNullException(nameof(recorder)));

    public static T AddRecorder<T>(this T instance, ICallRecorderFactory factory) =>
        CallRecorderProxyFactory.InternalAddRecorder(instance, factory: factory ?? throw new ArgumentNullException(nameof(factory)));

    public static bool TryGetRecorder<T>(this T instance, out ICallRecorder recorder)
    {
        if (instance is IHaveCallRecorder have)
        {
            recorder = have.Recorder;
            return true;
        }

        recorder = default;
        return false;
    }

    internal static bool AllowRecording(this MethodInfo method) => method switch
    {
        null => false,
        _ when method.HasAttribute<ExcludeFromRecordingAttribute>() => false,
        _ when method.DeclaringType?.HasAttribute<ExcludeFromRecordingAttribute>() ?? false => false,
        _ => true
    };
}
