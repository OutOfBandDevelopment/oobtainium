using System;
using System.Linq;
using System.Reflection;

namespace OoBDev.Oobtainium.Generation
{
    public class ProcedualGenerationSeedGenerator : IProcedualGenerationSeedGenerator
    {
        public int Generate(int seed, MethodBase method, object[] arguments) =>
            arguments.Aggregate(
                HashCode.Combine(seed, method.DeclaringType.FullName, method.Name),
                (s, v) => HashCode.Combine(s, v ?? 0)
                );

        public int Generate(int seed, Type type) => HashCode.Combine(seed, type.FullName);
    }
}
