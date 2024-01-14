using OoBDev.Oobtainium.Devices.ElectronicScoringMachines.Fencing.Common;
using OoBDev.Oobtainium.Devices.ElectronicScoringMachines.Fencing.SaintGeorge;
using OoBDev.Oobtainium.IO;
using OoBDev.Oobtainium.IO.Messages;
using OoBDev.Oobtainium.IO.Ports;
using OoBDev.Oobtainium.IO.Segmenters;
using System.ComponentModel;

namespace OoBDev.Oobtainium.Devices.Fencing.SaintGeorge;

[SerialPort(9600, Parity.None, 8, StopBits.One)]
[Description("Saint George")]
public class SgStateDefinition : IDeviceDefinitionReceiver<IScoreMachineState>
{
    public ISegmentBuildDefinition SegmentDefintion { get; } =
        Segment.StartsWith(ControlCharacters.StartOfHeading)
               .AndEndsWith(ControlCharacters.EndOfTransmission)
               .WithMaxLength(100)
               .WithOptions(SegmentionOptions.SkipInvalidSegment | SegmentionOptions.SecondStartInvalid);

    public IMessageDecoder<IScoreMachineState> Decoder { get; } = new SgStateDecoder();
}