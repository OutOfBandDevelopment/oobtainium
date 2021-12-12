using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OoBDev.Oobtainium.Generation
{
    public class GenerateObjectAttribute : Attribute, IGenerateObject
    {
        public static readonly int DefaultPriority = int.MaxValue;
        public int Priority { get; set; } = DefaultPriority;
        public override object TypeId => this;

        public bool CanGenerateValue(IProcedualGenerationContext context) =>
            !context.TargetType.IsInterface &&
            !context.TargetType.IsAbstract &&
            !context.TargetType.IsEnum &&
            !context.TargetType.IsPrimitive &&
            !context.TargetType.IsArray
            ;

        public virtual object? GenerateValue(IProcedualGenerationContext context)
        {
            // Select constructor and create
            var ctors = context.TargetType.GetConstructors(); //TODO: make this deterministic

            var ctor = ctors.Length switch
            {
                0 => null,
                1 => ctors[0],
                _ => ctors[context.Random.Next() % ctors.Length]
            };
            var obj = ctor switch
            {
                null => Activator.CreateInstance(context.TargetType),
                _ => ctor.Invoke(GenerateArguments(context.Provider.CreateContext(context, ctor, ctor.GetCustomAttributes()), ctor.GetParameters(), Enumerable.Empty<Attribute>()))
            };

            //update setable properties
            foreach (var property in context.TargetType.GetProperties().OrderBy(p => p.Name))
            {
                var setter = property.GetSetMethod();
                if (setter != null)
                {
                    var setterAttributes = property.GetCustomAttributes().Concat(setter.GetCustomAttributes());
                    var setterContext = context.Provider.CreateContext(context, setter, setterAttributes);
                    setter.Invoke(obj, GenerateArguments(setterContext, setter.GetParameters(), setterAttributes));
                }
            }

            //update writable fields
            foreach (var field in context.TargetType.GetFields().OrderBy(p => p.Name))
            {
                var nestedContext = context.Provider.CreateContext(context, field.FieldType, field.GetCustomAttributes());
                var value = context.Provider.Generate(nestedContext);
                field.SetValue(obj, value);
            }

            return obj;
        }

        internal object?[] GenerateArguments(IProcedualGenerationContext context, ParameterInfo[] parameters, IEnumerable<Attribute> attributes)
        {
            var arguments = new object?
                [parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                var parameterAttributes = attributes.Concat(parameter.GetCustomAttributes());
                var nestedContext = context.Provider.CreateContext(context, parameter.ParameterType, parameterAttributes);
                var value = context.Provider.Generate(nestedContext);
                arguments[i] = value;
            }
            return arguments;
        }
    }
}
