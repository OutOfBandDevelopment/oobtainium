using System;

namespace OoBDev.Oobtainium.Devices.ElectronicScoringMachines.Fencing.Common;

public interface IParseScoreMachineState
{
    IScoreMachineState Parse(ReadOnlySpan<byte> frame);
}
