using System;
using System.Linq;
using System.Reflection;
using OoBDev.Oobtainium.Reflection.Recording;

namespace OoBDev.Oobtainium.Reflection.Recording;

public class RecordedCall : IRecordedCall
{
    public RecordedCall(object instance, Type? type, MethodInfo method, object[] arguments, object? response)
    {
        Instance = instance;
        Type = type;
        Method = method;
        Arguments = arguments ?? Array.Empty<object>();
        Response = response;
    }

    public object Instance { get; }
    public Type? Type { get; }
    public MethodInfo Method { get; }
    public object[] Arguments { get; }
    public object? Response { get; }

    public override string ToString() => string.Join(' ',
        Type == null ? $"{Method}" : $"{Type}::{Method}",
        Arguments.Length > 0 ? $"[{string.Join(';', Arguments.Select(a => $"{a}"))}]" : null,
        Response != null ? $"=> {Response}" : null
        );
}
