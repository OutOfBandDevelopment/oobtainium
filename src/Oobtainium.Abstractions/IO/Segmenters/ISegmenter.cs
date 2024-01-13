using System.Buffers;
using System.Threading.Tasks;

namespace OoBDev.Oobtainium.IO.Segmenters;

public interface ISegmenter
{
    ValueTask<ISegmentReadResult> TryReadAsync(ReadOnlySequence<byte> buffer);
}