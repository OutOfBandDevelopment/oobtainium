namespace OoBDev.Oobtainium.IO;

public interface IBufferedDeviceAdapter : IDeviceAdapter
{
    int BytesToRead { get; }
}
