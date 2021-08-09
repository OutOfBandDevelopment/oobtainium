using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OoBDev.Oobtainium.Recording
{
    public class CallRecorder : ICallRecorder
    {
        private readonly ILogger<ICallRecorder>? _log;
        private readonly SynchronizedCollection<IRecordedCall> _calls = new SynchronizedCollection<IRecordedCall>();

        public CallRecorder(ILogger<ICallRecorder>? log = null)
        {
            _log = log;
            Capture = RecordCall;
        }

        public CaptureHandler Capture { get; }

        public void Clear() => _calls.Clear();

        public IEnumerator<IRecordedCall> GetEnumerator() => _calls.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _calls.GetEnumerator();

        private void RecordCall(object instance, Type instanceAs, MethodInfo method, object[] arguments, object? response)
        {
            _log?.LogInformation($"{instance} as {instanceAs}: {method.Name}({string.Join(';', arguments.Select(i => i))}) => {response}");
            _calls.Add(new RecordedCall(instanceAs, method, arguments, response));
        }
    }
}
