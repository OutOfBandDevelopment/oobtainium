using System;

namespace OoBDev.Oobtainium.Devices.ElectronicScoringMachines.Fencing.Common;

[Flags]
public enum Lights
{
    None = 0x0,
    White = 0x1,
    Yellow = 0x2,
    Touch = 0x4,
}
