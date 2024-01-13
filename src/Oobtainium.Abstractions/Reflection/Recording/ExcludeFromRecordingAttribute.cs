using System;
using static System.AttributeTargets;

namespace OoBDev.Oobtainium.Reflection.Recording;

[AttributeUsage(Class | Interface | Method | Property, Inherited = true)]
public class ExcludeFromRecordingAttribute : Attribute
{
}
