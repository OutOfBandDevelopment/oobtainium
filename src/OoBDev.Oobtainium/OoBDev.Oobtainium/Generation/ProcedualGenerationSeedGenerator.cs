using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OoBDev.Oobtainium.Generation
{
    public class ProcedualGenerationSeedGenerator : IProcedualGenerationSeedGenerator
    {
        public int Generate(int seed, MethodBase method, object[] arguments) => Seed(Basis(seed, method, arguments));
        public int Generate(int seed, Type type) => Seed(Basis(seed, type));

        internal int Seed(string input)
        {
            var basis = Encoding.UTF8.GetBytes(input ?? "");
            var paddedEncoding = basis.Concat(new byte[4 - (basis.Length % 4)]).ToArray();
            var seed = Enumerable.Range(0, paddedEncoding.Length / 4)
                                 .Select(i => BitConverter.ToInt32(paddedEncoding, i * 4))
                                 .Aggregate(0, (a, b) => a ^ b)
                                 ;
            return seed;
        }

        internal string Basis(int seed, MethodBase method, object[] arguments) =>
            new
            {
                seed,
                method.DeclaringType?.FullName,
                method.Name,
                Arguments = string.Join(";", from i in Enumerable.Range(0, method.GetParameters().Length)
                                             let p = method.GetParameters()[i]
                                             let v = arguments.ElementAtOrDefault(i)
                                             select $"{p.Name} = {v}"), //TODO: the object value here should capture the hierarchy
            }.ToString();

        internal string Basis(int seed, Type type) =>
            new
            {
                seed,
                type.FullName,
            }.ToString();
    }
}
