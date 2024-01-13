using OoBDev.Oobtainium.IO.Messages;
using OoBDev.Oobtainium.IO.Segmenters;

namespace OoBDev.Oobtainium.IO;

public interface IDeviceDefinitionReceiver<TMessage> : IDeviceDefinition<TMessage>
{
    ISegmentBuildDefinition SegmentDefintion { get; }
    IMessageDecoder<TMessage> Decoder { get; }
}
