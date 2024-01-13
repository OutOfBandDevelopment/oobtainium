using OoBDev.Oobtainium.IO;
using OoBDev.Oobtainium.IO.Messages;
using OoBDev.Oobtainium.IO.Ports;
using OoBDev.Oobtainium.IO.Segmenters;
using OoBDev.Oobtainium.IO.UsbHids;
using System.ComponentModel;
using System.Composition;
using static OoBDev.Oobtainium.IO.Bytes;

namespace OoBDev.Oobtainium.Devices.Nmea;

[SerialPort(4800)]
[UsbHid(0x1163, 0x200)]
[Description("NEMA 0183")]
[Export(typeof(IDeviceDefinition))]
public class Nema0183Definition : IDeviceDefinitionReceiver<INema0183Message>
{
    public ISegmentBuildDefinition SegmentDefintion => Segment.StartsWith("$!"u8.ToArray()).AndEndsWith(Lf);
    public IMessageDecoder<INema0183Message> Decoder { get; } = new Nema0183Decoder();
}
