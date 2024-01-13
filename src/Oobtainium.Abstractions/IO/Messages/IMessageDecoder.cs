using System.Buffers;

namespace OoBDev.Oobtainium.IO.Messages;

public interface IMessageDecoder<TResponse>
{
    TResponse Decode(ReadOnlySequence<byte> response);
}
