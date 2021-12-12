using System;
using System.Reflection;

namespace OoBDev.Oobtainium.Generation
{
    public interface IProcedualGenerationSeedGenerator
    {
        int Generate(int seed, MethodBase method, object[] arguments);
        int Generate(int seed, Type type);
    }
}
