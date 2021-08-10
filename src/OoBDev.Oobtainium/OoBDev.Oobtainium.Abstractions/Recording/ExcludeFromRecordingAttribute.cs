using System;
using static System.AttributeTargets;

namespace OoBDev.Oobtainium.Recording
{
    [AttributeUsage(Class | Interface | Method | Property, Inherited = true)]
    public sealed class ExcludeFromRecordingAttribute : Attribute
    {
    }
}
