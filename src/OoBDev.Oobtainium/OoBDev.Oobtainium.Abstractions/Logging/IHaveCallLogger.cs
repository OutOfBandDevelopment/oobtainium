using Microsoft.Extensions.Logging;
using OoBDev.Oobtainium.Recording;

namespace OoBDev.Oobtainium.Logging
{
    [ExcludeFromRecording]
    public interface IHaveCallLogger
    {
        ILogger Logger { get; }
    }
}
