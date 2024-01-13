using System.Buffers;

namespace OoBDev.Oobtainium.IO.Segmenters;

public interface ISegmentReadResult
{
    SegmentationStatus Status { get; }
    ReadOnlySequence<byte> RemainingData { get; }
}