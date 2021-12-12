using System;

namespace OoBDev.Oobtainium.Generation
{
    public abstract class GenerateNullableAttribute : Attribute, IGenerateObject
    {
        public static readonly int DefaultPriority = GenerateObjectAttribute.DefaultPriority - 1;
        public virtual int Priority { get; set; } = DefaultPriority;
        public override object TypeId => this;

        public object? GenerateValue(IProcedualGenerationContext context)
        {
            if (MakeNull(context)) return null;

            return OnGenerateValue(context);
        }

        public abstract bool CanGenerateValue(IProcedualGenerationContext context);

        protected abstract object? OnGenerateValue(IProcedualGenerationContext context);

        protected bool MakeNull(IProcedualGenerationContext context) =>
            context.TargetType == null || (Nullable.GetUnderlyingType(context.TargetType) != null && context.Random.Next() % 4 == 0);

    }
}
