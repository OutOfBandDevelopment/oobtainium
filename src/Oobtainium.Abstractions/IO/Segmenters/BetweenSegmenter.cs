using System.Buffers;
using System.Linq;

namespace OoBDev.Oobtainium.IO.Segmenters;

internal sealed class BetweenSegmenter : SegmenterBase
{
    internal BetweenSegmenter(
        OnSegmentReceived onSegmentReceived,
        byte[] starts,
        byte end,
        long? maxLength,
        SegmentionOptions options
        )
        : base(onSegmentReceived, options)
    {
        Starts = starts;
        End = end;
        MaxLength = maxLength;
    }

    internal byte[] Starts { get; }
    internal byte End { get; }
    internal long? MaxLength { get; }

    protected override (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer)
    {
        var startOfSegment = Starts.Select(start => buffer.PositionOf(start)).FirstOrDefault(start => start != null);
        if (startOfSegment != null)
        {
            var segment = buffer.Slice(startOfSegment.Value);

            var endOfSegment = segment.PositionOf(End);
            if (endOfSegment != null)
            {
                var completeSegment = segment.Slice(0, segment.GetPosition(1, endOfSegment.Value));

                if (Options.HasFlag(SegmentionOptions.SecondStartInvalid))
                {
                    var secondStart = Starts.Select(start => completeSegment.PositionOf(start)).FirstOrDefault(start => start != null);
                    if (secondStart != null)
                    {
                        // Second start detected
                        return (SegmentationStatus.Invalid, buffer.Slice(0, secondStart.Value));
                    }
                }

                return (SegmentationStatus.Complete, completeSegment);
            }
            else if (MaxLength.HasValue && buffer.Length > MaxLength)
            {
                var leftover = buffer.Length % MaxLength.Value;
                buffer = buffer.Slice(0, buffer.GetPosition(-leftover, buffer.End));
                return (SegmentationStatus.Invalid, buffer);
            }
        }

        return (SegmentationStatus.Incomplete, null);
    }
}