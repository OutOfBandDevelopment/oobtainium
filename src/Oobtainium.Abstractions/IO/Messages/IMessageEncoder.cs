using System;

namespace OoBDev.Oobtainium.IO.Messages;

public interface IMessageEncoder<TMessage>
{
    ReadOnlyMemory<byte> Encode(ref TMessage request);
}
