using System;

namespace OoBDev.Oobtainium.MetaData;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class MediaTypeAttribute(string mediaType) : Attribute
{
    public string MediaType { get; } = mediaType;
}
