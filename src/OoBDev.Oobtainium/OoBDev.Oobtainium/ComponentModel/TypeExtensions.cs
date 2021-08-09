using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace OoBDev.Oobtainium.ComponentModel
{
    public static class TypeExtensions
    {
        public static object? GetDefaultValue(this Type type) =>
            type == null ? null :
            type == typeof(void) ? null :
            type.IsValueType ? Activator.CreateInstance(type) :
            null
            ;

        public static object? ConvertOrDefault(this Type type, object? input)
        {
            var task = input as Task;
            var captured = task?.GetResultOrDefault() ?? input;
            if (task != null) task.GetAwaiter().GetResult();

            if (type == null || type == typeof(void)) return null;
            if (type == typeof(Task)) return Task.CompletedTask;
            if (captured == null) return type.GetDefaultValue();
            if (type.IsInstanceOfType(captured)) return captured;

            var converter = TypeDescriptor.GetConverter(captured);
            if (converter.CanConvertTo(type)) return converter.ConvertTo(captured, type);

            if (typeof(Task).IsAssignableFrom(type) && type.IsGenericType)
            {
                var taskResultType = type.GetGenericArguments()[0];
                var wrapped = taskResultType.ConvertOrDefault(captured);
                return wrapped.AsTask();
            }

            return null;
        }
    }
}
