using System;
using System.Collections.Generic;
using System.Reflection;

namespace OoBDev.Oobtainium.Recording;

public delegate void CaptureHandler(object instance, Type instanceAs, MethodInfo method, object[] arguments, object? response);
/// <summary>
/// ICallRecorder adds support to capture proxy service calls in order of execution. 
/// </summary>
[ExcludeFromRecording]
public interface ICallRecorder : IEnumerable<IRecordedCall>
{
    CaptureHandler? Capture { get; }

    void Clear();
}
