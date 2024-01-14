using OoBDev.Oobtainium.Devices.ElectronicScoringMachines.Fencing.Common;
using OoBDev.Oobtainium.IO.Messages;
using System;
using System.Buffers;

namespace OoBDev.Oobtainium.Devices.ElectronicScoringMachines.Fencing.Favero;

public class FaveroDecoder : IMessageDecoder<IScoreMachineState>
{
    private readonly FaveroStateParser _parser = new();

    public IScoreMachineState Decode(ReadOnlySequence<byte> response)
    {
        Span<byte> buffer = new byte[response.Length];
        response.CopyTo(buffer);
        return _parser.Parse(buffer);
    }
}
