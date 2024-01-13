using System.Buffers;
using System.Threading.Tasks;

namespace OoBDev.Oobtainium.IO.Segmenters;

public delegate Task OnSegmentReceived(ReadOnlySequence<byte> segment);
