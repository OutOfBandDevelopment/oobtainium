using System;

namespace OoBDev.Oobtainium.IO.Functions;

public interface IChecksumCalculator
{
    ushort Simple16(ReadOnlySpan<ushort> buffer);
}