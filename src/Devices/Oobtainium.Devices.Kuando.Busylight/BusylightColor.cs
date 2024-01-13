using System.Runtime.InteropServices;

namespace OoBDev.Oobtainium.Devices.Kuando.Busylight;

[StructLayout(LayoutKind.Explicit, Size = 3)]
public struct BusylightColor
{
    [FieldOffset(0)]
    public byte Red;
    [FieldOffset(1)]
    public byte Green;
    [FieldOffset(2)]
    public byte Blue;
}
