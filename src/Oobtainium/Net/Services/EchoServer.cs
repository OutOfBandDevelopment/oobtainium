using OoBDev.Oobtainium.Net.Sockets;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace OoBDev.Oobtainium.Net.Services;

public class EchoServer(IPAddress? ipAddress = default, ushort port = 7) : ServerBase(ipAddress, port)
{
    protected override async Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken)
    {
        await accepted.GetStream().WriteAsync(message, cancellationToken);
    }
}
