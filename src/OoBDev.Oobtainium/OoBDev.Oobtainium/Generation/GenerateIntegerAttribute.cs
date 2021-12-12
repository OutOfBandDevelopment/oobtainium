using System;
using System.Collections.Generic;
using System.Linq;

namespace OoBDev.Oobtainium.Generation
{
    public class GenerateIntegerAttribute : GenerateNullableAttribute
    {
        public override bool CanGenerateValue(IProcedualGenerationContext context) =>
            new[] {
                typeof(int), typeof(int?),
                typeof(uint), typeof(uint?),
                typeof(byte), typeof(byte?),
                typeof(sbyte), typeof(sbyte?),
            }.Contains(context.TargetType);

        protected override object? OnGenerateValue(IProcedualGenerationContext context)
        {
            var result = context.Random.Next();
            if (context.TargetType == typeof(uint) || context.TargetType == typeof(uint?)) return (uint)result;
            if (context.TargetType == typeof(byte) || context.TargetType == typeof(byte?)) return (byte)result;
            if (context.TargetType == typeof(sbyte) || context.TargetType == typeof(sbyte?)) return (sbyte)result;
            else return result;
        }
    }
}
