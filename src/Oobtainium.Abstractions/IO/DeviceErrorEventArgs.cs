using System;

namespace OoBDev.Oobtainium.IO;

public class DeviceErrorEventArgs(Exception exception, ErrorHandling errorHandling) : EventArgs
{
    public Exception Exception { get; } = exception;
    public ErrorHandling ErrorHandling { get; set; } = errorHandling;
}
