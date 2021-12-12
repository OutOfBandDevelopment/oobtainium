using System;
using System.Collections.Generic;
using System.Reflection;

namespace OoBDev.Oobtainium.Generation
{
    public interface IProcedualGenerationContextBuilder
    {
        IProcedualGenerationContext CreateContext(IProcedualGenerationProvider provider, IProcedualGenerationContext? context, Type type, IEnumerable<Attribute> attributes);
        IProcedualGenerationContext CreateContext(IProcedualGenerationProvider provider, IProcedualGenerationContext? context, MethodBase method, object[] args, IEnumerable<Attribute> attributes);
    }
}