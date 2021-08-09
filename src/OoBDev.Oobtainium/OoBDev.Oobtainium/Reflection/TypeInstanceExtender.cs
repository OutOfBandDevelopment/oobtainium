using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace OoBDev.Oobtainium.Reflection
{
    public static class TypeInstanceExtender
    {
        private static ModuleBuilder? _md;
        internal static ModuleBuilder GetModuleBuilder()
        {
            return _md ??= MakeModuleBuilder();

            static ModuleBuilder MakeModuleBuilder()
            {
                var assemblyName = new AssemblyName(Guid.NewGuid().ToString());
                var assembly = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
                var module = assembly.DefineDynamicModule(Guid.NewGuid().ToString());
                return module;
            }
        }
        private static ConcurrentDictionary<string, Type> _types = new ConcurrentDictionary<string, Type>();
        internal static Type AddInterfaceToInstanceType<T>(object instance, params Type[] additionalInterfaces)
        {
            var newInterfaces = new[] { typeof(T) }.Concat(additionalInterfaces ?? Type.EmptyTypes);
            if (newInterfaces.Any(i => !i.IsInterface))
            {
                throw new NotSupportedException($"additional types must be interfaces {string.Join(';', newInterfaces.Where(i => !i.IsInterface))}");
            }

            var existingType = instance.GetType();

            TypeDescriptor.Refresh(existingType);

            var interfaces = from inf in existingType.GetInterfaces().Concat(newInterfaces).Distinct()
                             let atts = TypeDescriptor.GetAttributes(inf).OfType<GeneratedInterfaceAttribute>()
                             where !atts.Any()
                             select inf;

            var typeName = string.Join('_', interfaces.Select(i => i.Name));

            return _types.GetOrAdd(typeName, t => BuildType(t, interfaces.ToArray()));

            static Type BuildType(string typeName, Type[] interfaces)
            {
                var typeBuilder = GetModuleBuilder()
                    .DefineType(
                        typeName,
                        TypeAttributes.Public | TypeAttributes.Interface | TypeAttributes.Abstract,
                        null,
                        interfaces)
                    ;
                var type = typeBuilder.CreateType();
                TypeDescriptor.AddAttributes(type, new GeneratedInterfaceAttribute());
                return type;
            }
        }

        internal static T AddInterface<T>(this object existing, Type proxyClass)
        {
            if (!typeof(T).IsInterface) throw new NotSupportedException($"<T> must be an interface ({typeof(T)})");
            if (proxyClass == null) throw new ArgumentNullException(nameof(proxyClass));
            if (!proxyClass.IsGenericType) throw new NotSupportedException($"{nameof(proxyClass)} must be generic");

            if (existing is T already) return already;
            else
            {
                //stack type here
                var type = AddInterfaceToInstanceType<T>(existing, typeof(INeedInstance));

                var proxyType = proxyClass.MakeGenericType(type);
                var createMethod = typeof(DispatchProxy).GetMethod(nameof(DispatchProxy.Create), BindingFlags.Static | BindingFlags.Public);
                var genericCreateMethod = createMethod.MakeGenericMethod(type, proxyType);
                var newProxy = genericCreateMethod.Invoke(null, null);
                var wrapped = (INeedInstance)newProxy;
                wrapped.Instance = (T)existing;
                return (T)newProxy;
            }
        }
    }
}
