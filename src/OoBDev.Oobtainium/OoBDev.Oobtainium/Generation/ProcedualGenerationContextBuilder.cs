using System;
using System.Collections.Generic;
using System.Reflection;

namespace OoBDev.Oobtainium.Generation
{
    public class ProcedualGenerationContextBuilder : IProcedualGenerationContextBuilder
    {
        public ProcedualGenerationContextBuilder(
            IProcedualGenerationSeedGenerator seedGenerator
            )
        {
            SeedGenerator = seedGenerator;
        }

        public IProcedualGenerationSeedGenerator SeedGenerator { get; }

        public IProcedualGenerationContext CreateContext(
            IProcedualGenerationProvider provider,
            IProcedualGenerationContext? context,
            Type type,
            IEnumerable<Attribute> attributes
            )
            => new ProcedualGenerationContext(
                seed: SeedGenerator.Generate(seed: context?.Seed ?? 0, type: type),
                targetType: type,
                relation: type,
                attributes: attributes,
                parent: context,
                provider: provider
                );

        public IProcedualGenerationContext CreateContext(
            IProcedualGenerationProvider provider,
            IProcedualGenerationContext? context,
            MethodBase method,
            object[] arguments,
            IEnumerable<Attribute> attributes
            )
            => new ProcedualGenerationContext(
                seed: SeedGenerator.Generate(seed: context?.Seed ?? 0, method: method, arguments: arguments),
                targetType: method switch
                {
                    MethodInfo m => m.ReturnType,
                    ConstructorInfo c => c.DeclaringType,

                    _ => throw new NotSupportedException($"")
                },
                relation: new { method, arguments },
                attributes: method.GetCustomAttributes(),
                parent: context,
                provider: provider
                );
    }
}
