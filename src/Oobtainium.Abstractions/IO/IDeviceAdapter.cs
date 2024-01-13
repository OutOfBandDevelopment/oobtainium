using System.IO;

namespace OoBDev.Oobtainium.IO;

public interface IDeviceAdapter
{
    string Type { get; }
    string Path { get; }

    bool TryOpen(out Stream? stream);
    Stream Stream { get; }
    //void Open();
}
