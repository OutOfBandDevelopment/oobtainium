using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using OoBDev.Oobtainium.Reflection;

namespace OoBDev.Oobtainium.ComponentModel;

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

    public static IEnumerable<Attribute> GetAttributes(this object instance) => instance switch
    {
        Type type => TypeDescriptor.GetAttributes(type).OfType<Attribute>(),
        _=> TypeDescriptor.GetAttributes(instance).OfType<Attribute>()
    };

    public static bool HasAttribute<TAttribute>(this object instance)
        where TAttribute : Attribute => 
        instance?.GetAttributes().Any(a => typeof(TAttribute).IsInstanceOfType(a)) ?? false;
}
