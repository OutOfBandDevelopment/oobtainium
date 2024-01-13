using System.Threading.Tasks;

namespace OoBDev.Oobtainium.IO;

public interface IDeviceTransmitter<TMessage> : IDevice<TMessage>
{
    Task<bool> Transmit(TMessage message);
}
