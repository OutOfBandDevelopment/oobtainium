using System.Collections.Generic;

namespace OoBDev.Oobtainium.IO;

public interface IImplictDeviceFactory : IDeviceFactory
{
    IDeviceAdapter? GetDevice(object? definition);
    IEnumerable<IDeviceAdapter> GetDevices(object? definition);
}
