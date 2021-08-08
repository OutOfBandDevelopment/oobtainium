using System;
using System.Reflection;

namespace OoBDev.Oobtainium
{
    public interface IRecordedCall
    {
        Type? Type { get; }
        MethodInfo Method { get; }
        object[] Arguments { get; }
        object? Response { get; }
    }

}
