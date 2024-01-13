using OoBDev.Oobtainium.Devices.ElectronicScoringMachines.Fencing.Common;
using OoBDev.Oobtainium.IO;
using OoBDev.Oobtainium.IO.Messages;
using OoBDev.Oobtainium.IO.Ports;
using OoBDev.Oobtainium.IO.Segmenters;
using System.ComponentModel;
using System.Composition;

namespace OoBDev.Oobtainium.Devices.ElectronicScoringMachines.Fencing.Favero;

[SerialPort(2400, Parity.None, 8, StopBits.One)]
[Description("Favero")]
[Export(typeof(IDeviceDefinition))]
public class FaveroDefinition : IDeviceDefinitionReceiver<IScoreMachineState>
{
    public ISegmentBuildDefinition SegmentDefintion { get; } =
        Segment.StartsWith(0xff)
               .AndIsLength(10)
               .WithOptions(SegmentionOptions.SkipInvalidSegment | SegmentionOptions.SecondStartInvalid);

    public IMessageDecoder<IScoreMachineState> Decoder { get; } = new FaveroDecoder();
}
