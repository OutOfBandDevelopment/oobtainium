using System;
using System.Linq;

namespace OoBDev.Oobtainium.Generation
{
    public class GenerateGuidAttribute : GenerateNullableAttribute
    {
        public override bool CanGenerateValue(IProcedualGenerationContext context) =>
            new[] {
                typeof(Guid), typeof(Guid?),
            }.Contains(context.TargetType);

        protected override object? OnGenerateValue(IProcedualGenerationContext context)
        {
            var buffer = new byte[16];
            context.Random.NextBytes(buffer);
            return new Guid(buffer);
        }
    }
}
