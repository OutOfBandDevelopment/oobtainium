using System;

namespace OoBDev.Oobtainium.Devices.ElectronicScoringMachines.Fencing.Common;

public interface IScoreMachineState
{
    /// <summary>
    /// Left
    /// </summary>
    Fencer Left { get; }
    /// <summary>
    /// Right
    /// </summary>
    Fencer Right { get; }
    TimeSpan Clock { get; }
    byte Match { get; }
}