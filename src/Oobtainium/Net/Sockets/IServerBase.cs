using System;
using System.Threading.Tasks;

namespace OoBDev.Oobtainium.Net.Sockets;

public interface IServerBase : IAsyncDisposable
{
    void Start();
    Task<IAsyncDisposable> StopAsync();
}
