using System;

namespace OoBDev.Oobtainium.TestUtilities.Logging;

internal class LoggerScope<TState>(TState state) : IDisposable
{
    public void Dispose() { }
}