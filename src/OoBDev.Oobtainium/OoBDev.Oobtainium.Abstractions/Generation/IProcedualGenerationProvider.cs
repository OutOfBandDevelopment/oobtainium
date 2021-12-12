using System;
using System.Collections.Generic;
using System.Reflection;

namespace OoBDev.Oobtainium.Generation
{
    public interface IProcedualGenerationProvider
    {
        IProcedualGenerationContext CreateContext(Type type);
        IProcedualGenerationContext CreateContext(Type type, IEnumerable<Attribute> attributes);
        IProcedualGenerationContext CreateContext(MethodBase method);
        IProcedualGenerationContext CreateContext(MethodBase method, IEnumerable<Attribute> attributes);
        IProcedualGenerationContext CreateContext(MethodBase method, object[] args);
        IProcedualGenerationContext CreateContext(MethodBase method, object[] args, IEnumerable<Attribute> attributes);

        IProcedualGenerationContext CreateContext(int index, Type type);
        IProcedualGenerationContext CreateContext(int index, Type type, IEnumerable<Attribute> attributes);
        IProcedualGenerationContext CreateContext(int index, MethodBase method);
        IProcedualGenerationContext CreateContext(int index, MethodBase method, IEnumerable<Attribute> attributes);
        IProcedualGenerationContext CreateContext(int index, MethodBase method, object[] args);
        IProcedualGenerationContext CreateContext(int index, MethodBase method, object[] args, IEnumerable<Attribute> attributes);

        IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, Type type);
        IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, Type type, IEnumerable<Attribute> attributes);
        IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, MethodBase method);
        IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, MethodBase method, IEnumerable<Attribute> attributes);
        IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, MethodBase method, object[] args);
        IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, MethodBase method, object[] args, IEnumerable<Attribute> attributes);

        IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, int index, Type type);
        IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, int index, Type type, IEnumerable<Attribute> attributes);
        IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, int index, MethodBase method);
        IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, int index, MethodBase method, IEnumerable<Attribute> attributes);
        IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, int index, MethodBase method, object[] args);
        IProcedualGenerationContext CreateContext(IProcedualGenerationContext context, int index, MethodBase method, object[] args, IEnumerable<Attribute> attributes);

        object? Generate(IProcedualGenerationContext context);
    }
}
