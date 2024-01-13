using System.Runtime.InteropServices;

namespace OoBDev.Oobtainium.IO.Tar;

[StructLayout(LayoutKind.Sequential)]
internal struct FILETIME
{
    internal uint dwLowDateTime;
    internal uint dwHighDateTime;
};
