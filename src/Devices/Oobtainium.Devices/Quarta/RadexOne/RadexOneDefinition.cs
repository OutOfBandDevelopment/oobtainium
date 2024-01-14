using OoBDev.Oobtainium.IO;
using OoBDev.Oobtainium.IO.Messages;
using OoBDev.Oobtainium.IO.Ports;
using OoBDev.Oobtainium.IO.Segmenters;
using System.ComponentModel;

namespace OoBDev.Oobtainium.Devices.Quarta.RadexOne;

[SerialPort(9600)]
[Description("Radex One")]
public class RadexOneDefinition : IDeviceDefinitionTransmitter<IRadexObject>, IDeviceDefinitionReceiver<IRadexObject>
{
    public IMessageEncoder<IRadexObject> Encoder { get; } = new MessageEncoder<IRadexObject>();

    public ISegmentBuildDefinition SegmentDefintion { get; } =
        Segment.StartsWith("z"u8.ToArray())
               .AndIsLength(12)
               .ExtendedWithLengthAt<ushort>(4, Endianness.Little)
               .WithOptions(SegmentionOptions.SkipInvalidSegment);

    public IMessageDecoder<IRadexObject> Decoder { get; } = new RadexOneDecoder();
}
