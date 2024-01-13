using OoBDev.Oobtainium.IO.Messages;

namespace OoBDev.Oobtainium.IO;

public interface IDeviceDefinitionTransmitter<TMessage> : IDeviceDefinition<TMessage>
{
    IMessageEncoder<TMessage> Encoder { get; }
}
