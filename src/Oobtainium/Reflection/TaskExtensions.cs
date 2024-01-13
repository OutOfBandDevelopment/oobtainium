using System;
using System.Reflection;
using System.Threading.Tasks;

namespace OoBDev.Oobtainium.Reflection;

public static class TaskExtensions
{
    public static Task AsTask(this object? input)
    {
        if (input == null) return Task.CompletedTask;
        var task = typeof(Task)
            .GetMethod(nameof(Task.FromResult), BindingFlags.Static | BindingFlags.Public)
            ?.MakeGenericMethod(input.GetType())
            ?.Invoke(null, new[] { input })
             as Task
            ;
        if (task == null) return Task.FromException(new NullReferenceException("Unable to resolve Task.FromResult<>()"));
        return task;
    }

    public static object? GetResultOrDefault(this Task? task)
    {
        if (task != null)
        {
            task.GetAwaiter().GetResult();
            var taskType = task.GetType();
            if (taskType.IsGenericType)
            {
                var result = taskType.GetProperty("Result")?.GetValue(task, null);
                return result;
            }
        }
        return null;
    }
}
