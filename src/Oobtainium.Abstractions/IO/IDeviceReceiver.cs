using System;

namespace OoBDev.Oobtainium.IO;

public interface IDeviceReceiver<TMessage> : IDevice<TMessage>
{
    event EventHandler<TMessage> MessageReceived;
}
