using System;
using System.Reflection;

namespace OoBDev.Oobtainium.Recording;

/// <summary>
/// Captured invocation
/// </summary>
[ExcludeFromRecording]
public interface IRecordedCall
{
    object Instance { get; }

    /// <summary>
    /// Target type for calls that was invoked.  When using the generic interfaces this will be the interface provided to the proxy factory.
    /// </summary>
    Type? Type { get; }

    /// <summary>
    /// MethodInfo related to the actual operation being invoked
    /// </summary>
    MethodInfo Method { get; }

    /// <summary>
    /// Function parameters for method. Index order will match parameters on Method.
    /// </summary>
    object[] Arguments { get; }

    /// <summary>
    /// Captured response from invocation.  This may be null if the function is void return. If no interception was provided this will be default(ReturnType)
    /// </summary>
    object? Response { get; }
}