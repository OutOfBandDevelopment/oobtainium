using System;
using System.Reflection;

namespace OoBDev.Oobtainium.Generation
{
    public interface IProcedualGenerationSeedGenerator
    {
        int Generate(int seed, int index, MethodBase method, object[] arguments);
        int Generate(int seed, int index, Type type);
    }
}
