using System;

namespace OoBDev.Oobtainium.IO;

public interface ITempFile : IDisposable
{
    string FilePath { get; }
}
