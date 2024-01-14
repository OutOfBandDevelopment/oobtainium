using OoBDev.Oobtainium.IO.Messages;

namespace OoBDev.Oobtainium.Devices.Quarta.RadexOne;

/// <summary>
/// used to convert buffered data to correct value type
/// </summary>
public interface IRadexOneDecoder : IMessageDecoder<IRadexObject>
{
}