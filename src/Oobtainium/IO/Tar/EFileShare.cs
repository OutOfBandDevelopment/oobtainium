using System;

namespace OoBDev.Oobtainium.IO.Tar;

[Flags]
public enum EFileShare : uint
{
    None = 0x00000000,
    Read = 0x00000001,
    Write = 0x00000002,
    Delete = 0x00000004,
}
