using System;
using System.Diagnostics;
using BinaryDataDecoders.Net;

namespace OoBDev.Oobtainium.Net;

public class InvalidMacAddressException(string macAddress) : Exception(string.Format("\"{0}\" is not a valid MAC Address", macAddress))
{
    public string MACAddress { get; } = macAddress;

    [DebuggerNonUserCode]
    public static void Check(string macAddress)
    {
        if (!MacAddressEx.IsValid(macAddress))
            throw new InvalidMacAddressException(macAddress);
    }
}
