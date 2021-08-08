using System;
using System.Collections.Generic;
using System.Reflection;

namespace OoBDev.Oobtainium
{
    public delegate void CaptureHandler(object instance, Type instanceAs, MethodInfo method, object[] arguments, object? response);
    public interface ICallRecorder : IEnumerable<IRecordedCall>
    {
        CaptureHandler? Capture { get; }
    }
}
