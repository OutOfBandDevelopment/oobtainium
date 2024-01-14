﻿using OoBDev.Oobtainium.IO;
using OoBDev.Oobtainium.IO.Messages;
using OoBDev.Oobtainium.IO.Segmenters;
using OoBDev.Oobtainium.IO.UsbHids;
using System.ComponentModel;

namespace OoBDev.Oobtainium.Devices.Velleman.K8055;

[UsbHid(vendorId: 0x10cf, productId: 0x5500, ProductMask = 0xfff8)]
[Description("Velleman K8055")]
public class K8055Definition :
    IDeviceDefinitionReceiver<IK8055Object>,
    IDeviceDefinitionTransmitter<IK8055Object>
{
    public IMessageEncoder<IK8055Object> Encoder { get; } = new MessageEncoder<IK8055Object>();
    public ISegmentBuildDefinition SegmentDefintion { get; } =
        Segment.PassThough()
               .AndIsLength(9)
               .WithOptions(SegmentionOptions.SkipInvalidSegment);

    public IMessageDecoder<IK8055Object> Decoder { get; } = new K8055Decoder();
}