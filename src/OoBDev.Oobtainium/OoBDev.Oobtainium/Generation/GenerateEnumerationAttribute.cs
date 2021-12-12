using System;

namespace OoBDev.Oobtainium.Generation
{
    public class GenerateEnumerationAttribute : GenerateNullableAttribute
    {
        public override bool CanGenerateValue(IProcedualGenerationContext context) =>
            context.TargetType.IsEnum ||
            (Nullable.GetUnderlyingType(context.TargetType)?.IsEnum ?? false)
            ;

        protected override object? OnGenerateValue(IProcedualGenerationContext context)
        {
            var values = Enum.GetValues(context.TargetType);
            var index = context.Random.Next() % values.Length;
            var result = values.GetValue(index);
            return result;
        }
    }
}
