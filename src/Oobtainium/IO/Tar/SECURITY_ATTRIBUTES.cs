using System.Runtime.InteropServices;

namespace OoBDev.Oobtainium.IO.Tar;

[StructLayout(LayoutKind.Sequential)]
public struct SECURITY_ATTRIBUTES
{
    public int nLength;
    public nint lpSecurityDescriptor;
    public int bInheritHandle;
}
