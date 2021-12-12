using System;
using System.Linq;

namespace OoBDev.Oobtainium.Generation
{
    public class GenerateLongAttribute : GenerateNullableAttribute
    {
        public override bool CanGenerateValue(IProcedualGenerationContext context) =>
            new[] {
                typeof(long), typeof(long?),
                typeof(ulong), typeof(ulong?),
            }.Contains(context.TargetType);

        protected override object? OnGenerateValue(IProcedualGenerationContext context)
        {
            var result = (long)context.Random.Next() << 32 | (long)context.Random.Next();

            if (context.TargetType == typeof(ulong) || context.TargetType == typeof(ulong?)) return (ulong)result;
            else return result;
        }
    }
}
