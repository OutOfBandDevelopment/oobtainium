using System;

namespace OoBDev.Oobtainium.MetaData;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class FileExtensionAttribute(string fileExtension) : Attribute
{
    public string FileExtension { get; } = fileExtension;
}
