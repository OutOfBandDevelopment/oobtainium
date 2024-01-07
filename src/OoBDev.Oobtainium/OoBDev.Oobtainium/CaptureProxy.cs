using Microsoft.Extensions.Logging;
using OoBDev.Oobtainium.ComponentModel;
using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Threading.Tasks;

namespace OoBDev.Oobtainium;

public class CaptureProxy<I> : DispatchProxy, IHaveCallHandler, IHaveCallBindingStore
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private ICallHandler _handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    ICallHandler IHaveCallHandler.Handler => _handler;
    ICallBindingStore IHaveCallBindingStore.Store => _handler.Store;

    private ILogger<I>? _logger;

    //TODO: this backing store should move the CallBindingStore
    private readonly ConcurrentDictionary<string, object?> _backingStore = new();

    protected override object Invoke(MethodInfo targetMethod, object[] args)
    {
        _logger?.LogInformation($"{targetMethod}");

        var response = _handler?.Invoke(targetMethod, args);
        var captured = response;

        if (response is Task task)
        {
            _logger?.LogDebug($"{_handler} response is Task so await result");
            var awaited = task;
            awaited.GetAwaiter().GetResult();

            var awaitedType = response.GetType();
            if (awaitedType.IsGenericType)
            {
                _logger?.LogDebug($"{_handler} is a Task<> so unwrap result");
                captured = awaitedType.GetProperty("Result")?.GetValue(response, null);
            }
            else
            {
                _logger?.LogDebug($"{_handler} is a Task<void> change capture to null");
                captured = default;
            }
        }

        //if the method is a property act like you have a backing store
        if (targetMethod.IsSpecialName)
        {
            _logger?.LogDebug($"{targetMethod} is special");
            if (targetMethod.Name.StartsWith("set_"))
            {
                var key = targetMethod.Name[4..] + (args.Length > 1 ? '[' + string.Join(';', args[..^1]) + ']' : "");
                var value = args.Length == 0 ? args[0] : args[^1];

                //TODO: look at an indexer
                _logger?.LogDebug($"{key} is acting like a setter");
                _backingStore.AddOrUpdate(key, value, (k, v) => value);
            }
            else if (targetMethod.Name.StartsWith("get_"))
            {
                var key = targetMethod.Name[4..] + (args.Length > 0 ? '[' + string.Join(';', args) + ']' : "");
                _logger?.LogDebug($"{key} is acting like a getter");
                _backingStore.TryGetValue(key, out captured);
            }
            else
            {
                _logger?.LogDebug($"{targetMethod} is not that special");
            }
        }

        //TODO: add type converter support

        if (targetMethod.ReturnType == null || targetMethod.ReturnType == typeof(void))
        {
            return null;
        }
        else if (targetMethod.ReturnType.IsInstanceOfType(captured))
        {
            return captured;
        }
        else if (captured is Delegate)
        {
            return captured;
        }
        else if (typeof(Task).IsAssignableFrom(targetMethod.ReturnType))
        {
            var taskType = targetMethod.ReturnType;
            if (taskType.IsGenericType)
            {
                _logger?.LogDebug($"{targetMethod}.ReturnType is a Task<> so rebuild Task<>");

                //rewrap captured value
                var taskReturnType = taskType.GetGenericArguments()[0];
                if (taskReturnType == typeof(string) && captured is not string)
                {
                    if (captured is byte[] buffer)
                    {
                        captured = Convert.ToBase64String(buffer);
                    }
                    else
                    {
                        captured = captured?.ToString();
                    }
                }
                else if (!taskReturnType.IsInstanceOfType(captured))
                {
                    _logger?.LogDebug($"{captured} not assignable so get default value instead");
                    captured = taskReturnType.GetDefaultValue();
                }

                var fromResult = typeof(Task).GetMethod(nameof(Task.FromResult), BindingFlags.Static | BindingFlags.Public)?.MakeGenericMethod(taskReturnType)
                    ?? throw new NullReferenceException("Unable to resolve Task.FromResult<>");
                var result = fromResult.Invoke(null, [captured]);
                return result;
            }
            else
            {
                _logger?.LogDebug($"{targetMethod}.ReturnType is a Task so return completed");
                return Task.CompletedTask;
            }
        }
        // can is cast?
        // operator over load
        // convert?
        else
        {
            var @default = targetMethod.ReturnType.GetDefaultValue();
            return @default;
        }
    }

    internal static I Create(
        ICallHandler? handler = null,
        ILogger<I>? logger = null
        )
    {
        object? proxy = Create<I, CaptureProxy<I>>();
        if (proxy != null)
        {
            var unwrapped = (CaptureProxy<I>)proxy;
            unwrapped._handler = handler ?? new CallHandler();
            unwrapped._logger = logger;
        }
#pragma warning disable CS8603 // Possible null reference return.
        return (I)proxy;
#pragma warning restore CS8603 // Possible null reference return.
    }
}
