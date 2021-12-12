using System;
using System.Collections.Generic;
using System.Linq;

namespace OoBDev.Oobtainium.Generation
{
    public class GenerateDoubleAttribute : GenerateNullableAttribute
    {
        public override bool CanGenerateValue(IProcedualGenerationContext context) =>
            new[] {
                typeof(double), typeof(double?),
                typeof(float), typeof(float?),
                typeof(decimal), typeof(decimal?),
            }.Contains(context.TargetType);

        protected override object? OnGenerateValue(IProcedualGenerationContext context)
        {
            var result = context.Random.NextDouble();

            if (context.TargetType == typeof(float) || context.TargetType == typeof(float?)) return (float)result;
            else if (context.TargetType == typeof(decimal) || context.TargetType == typeof(decimal?)) return (decimal)result;
            else return result;
        }
    }
}
