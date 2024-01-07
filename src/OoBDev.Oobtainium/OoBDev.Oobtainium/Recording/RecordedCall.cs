using System;
using System.Linq;
using System.Reflection;

namespace OoBDev.Oobtainium.Recording;

public class RecordedCall(object instance, Type? type, MethodInfo method, object[] arguments, object? response) : IRecordedCall
{
    public object Instance { get; } = instance;
    public Type? Type { get; } = type;
    public MethodInfo Method { get; } = method;
    public object[] Arguments { get; } = arguments ?? [];
    public object? Response { get; } = response;

    public override string ToString() => string.Join(' ',
        Type == null ? $"{Method}" : $"{Type}::{Method}",
        Arguments.Length > 0 ? $"[{string.Join(';', Arguments.Select(a => $"{a}"))}]" : null,
        Response != null ? $"=> {Response}" : null
        );
}
