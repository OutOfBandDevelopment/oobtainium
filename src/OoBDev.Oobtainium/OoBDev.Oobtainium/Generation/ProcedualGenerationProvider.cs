using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace OoBDev.Oobtainium.Generation
{
    public class ProcedualGenerationProvider : IProcedualGenerationProvider
    {
        public IProcedualGenerationContextBuilder ContextBuilder { get; }

        public ProcedualGenerationProvider(IProcedualGenerationContextBuilder contextBuilder) => ContextBuilder = contextBuilder;

        static ProcedualGenerationProvider()
        {
            TypeDescriptor.AddAttributes(typeof(object), new GenerateObjectAttribute());

            TypeDescriptor.AddAttributes(typeof(Enum), new GenerateEnumerationAttribute());
            TypeDescriptor.AddAttributes(typeof(object), new GenerateArrayAttribute());

            TypeDescriptor.AddAttributes(typeof(byte), new GenerateIntegerAttribute());
            TypeDescriptor.AddAttributes(typeof(byte?), new GenerateIntegerAttribute());
            TypeDescriptor.AddAttributes(typeof(sbyte), new GenerateIntegerAttribute());
            TypeDescriptor.AddAttributes(typeof(sbyte?), new GenerateIntegerAttribute());

            TypeDescriptor.AddAttributes(typeof(int), new GenerateIntegerAttribute());
            TypeDescriptor.AddAttributes(typeof(int?), new GenerateIntegerAttribute());
            TypeDescriptor.AddAttributes(typeof(uint), new GenerateIntegerAttribute());
            TypeDescriptor.AddAttributes(typeof(uint?), new GenerateIntegerAttribute());

            TypeDescriptor.AddAttributes(typeof(long), new GenerateLongAttribute());
            TypeDescriptor.AddAttributes(typeof(long?), new GenerateLongAttribute());
            TypeDescriptor.AddAttributes(typeof(ulong), new GenerateLongAttribute());
            TypeDescriptor.AddAttributes(typeof(ulong?), new GenerateLongAttribute());

            TypeDescriptor.AddAttributes(typeof(DateTime), new GenerateDateTimeAttribute());
            TypeDescriptor.AddAttributes(typeof(DateTime?), new GenerateDateTimeAttribute());
            TypeDescriptor.AddAttributes(typeof(TimeSpan), new GenerateDateTimeAttribute());
            TypeDescriptor.AddAttributes(typeof(TimeSpan?), new GenerateDateTimeAttribute());
            TypeDescriptor.AddAttributes(typeof(DateTimeOffset), new GenerateDateTimeAttribute());
            TypeDescriptor.AddAttributes(typeof(DateTimeOffset?), new GenerateDateTimeAttribute());

            TypeDescriptor.AddAttributes(typeof(decimal), new GenerateDoubleAttribute());
            TypeDescriptor.AddAttributes(typeof(decimal?), new GenerateDoubleAttribute());
            TypeDescriptor.AddAttributes(typeof(double), new GenerateDoubleAttribute());
            TypeDescriptor.AddAttributes(typeof(double?), new GenerateDoubleAttribute());
            TypeDescriptor.AddAttributes(typeof(float), new GenerateDoubleAttribute());
            TypeDescriptor.AddAttributes(typeof(float?), new GenerateDoubleAttribute());

            TypeDescriptor.AddAttributes(typeof(Guid), new GenerateGuidAttribute());
            TypeDescriptor.AddAttributes(typeof(Guid?), new GenerateGuidAttribute());

            TypeDescriptor.AddAttributes(typeof(string), new GenerateStringAttribute());

            //TODO: interface support
            //TODO: abstract support
            //TODO: array (typed)
            //TODO: array of objects (object[])
            //TODO: collection, list support
            //TODO: dictionary support
            //TODO: random data object
        }

        public object? Generate(IProcedualGenerationContext context) =>
            (
                GetGenerators(context, context.Attributes).FirstOrDefault() ??
                GetGenerators(context, TypeDescriptor.GetAttributes(context.TargetType).OfType<Attribute>()).FirstOrDefault() ??
                throw new NotSupportedException($@"""{context.TargetType}"" is not supported")
            ).GenerateValue(context);

        internal IEnumerable<IGenerateObject> GetGenerators(IProcedualGenerationContext context, IEnumerable<Attribute> attributes)
            => from g in attributes.OfType<IGenerateObject>()
               orderby g.Priority
               where g.CanGenerateValue(context)
               select g;


        #region Overloads 

        public IProcedualGenerationContext CreateContext(Type type)
            => CreateContext(null, 0, type, Enumerable.Empty<Attribute>());
        public IProcedualGenerationContext CreateContext(Type type, IEnumerable<Attribute> attributes)
            => CreateContext(null, 0, type, attributes);
        public IProcedualGenerationContext CreateContext(int index, Type type)
            => CreateContext(null, index, type, Enumerable.Empty<Attribute>());
        public IProcedualGenerationContext CreateContext(int index, Type type, IEnumerable<Attribute> attributes)
            => CreateContext(null, index, type, attributes);

        public IProcedualGenerationContext CreateContext(MethodBase method)
            => CreateContext(null, 0, method, Array.Empty<object>(), Enumerable.Empty<Attribute>());
        public IProcedualGenerationContext CreateContext(MethodBase method, IEnumerable<Attribute> attributes)
            => CreateContext(null, 0, method, attributes);
        public IProcedualGenerationContext CreateContext(MethodBase method, object[] args)
            => CreateContext(null, 0, method, Enumerable.Empty<Attribute>());
        public IProcedualGenerationContext CreateContext(MethodBase method, object[] args, IEnumerable<Attribute> attributes)
            => CreateContext(null, 0, method, args, attributes);
        public IProcedualGenerationContext CreateContext(int index, MethodBase method)
            => CreateContext(null, index, method, Array.Empty<object>(), Enumerable.Empty<Attribute>());
        public IProcedualGenerationContext CreateContext(int index, MethodBase method, IEnumerable<Attribute> attributes)
            => CreateContext(null, index, method, Array.Empty<object>(), attributes);
        public IProcedualGenerationContext CreateContext(int index, MethodBase method, object[] args)
            => CreateContext(null, index, method, args, Enumerable.Empty<Attribute>());
        public IProcedualGenerationContext CreateContext(int index, MethodBase method, object[] args, IEnumerable<Attribute> attributes)
            => CreateContext(null, index, method, args, Enumerable.Empty<Attribute>());

        public IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, Type type)
            => CreateContext(context, 0, type, Enumerable.Empty<Attribute>());
        public IProcedualGenerationContext CreateContext(IProcedualGenerationContext? context, Type type, IEnumerable<Attribute> attributes)
            => CreateContext(context, 0, type, attributes);
        public IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, int index, Type type)
            => CreateContext(context, index, type, Enumerable.Empty<Attribute>());
        public IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, MethodBase method)
            => CreateContext(context, 0, method, Enumerable.Empty<Attribute>());
        public IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, MethodBase method, IEnumerable<Attribute> attributes)
            => CreateContext(context, 0, method, Array.Empty<object>(), Enumerable.Empty<Attribute>());
        public IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, MethodBase method, object[] args)
            => CreateContext(context, 0, method, args, Enumerable.Empty<Attribute>());
        public IProcedualGenerationContext CreateContext(IProcedualGenerationContext? context, MethodBase method, object[] args, IEnumerable<Attribute> attributes)
                    => CreateContext(context, 0, method, args, attributes);
        public IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, int index, MethodBase method)
            => CreateContext(context, 0, method, Array.Empty<object>(), Enumerable.Empty<Attribute>());
        public IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, int index, MethodBase method, IEnumerable<Attribute> attributes)
            => CreateContext(context, 0, method, Array.Empty<object>(), Enumerable.Empty<Attribute>());
        public IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, int index, MethodBase method, object[] args)
            => CreateContext(context, 0, method, args, Enumerable.Empty<Attribute>());

        #endregion Overloads 


        public IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, int index, Type type, IEnumerable<Attribute> attributes)
             => ContextBuilder.CreateContext(this, context, index, type, attributes);

        public IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, int index, MethodBase method, object[] args, IEnumerable<Attribute> attributes)
            => ContextBuilder.CreateContext(this, context, index, method, args, attributes);
    }
}
