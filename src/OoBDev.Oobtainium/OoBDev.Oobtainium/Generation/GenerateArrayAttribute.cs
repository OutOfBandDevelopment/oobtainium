using System;

namespace OoBDev.Oobtainium.Generation
{
    public class GenerateArrayAttribute : Attribute, IGenerateObject
    {
        public static readonly int DefaultPriority = GenerateObjectAttribute.DefaultPriority;
        public int Priority { get; set; } = DefaultPriority;
        public override object TypeId => this;

        public bool CanGenerateValue(IProcedualGenerationContext context) => context.TargetType.IsArray;

        public object? GenerateValue(IProcedualGenerationContext context)
        {
            var maxLength = 10;
            var arrayLength = context.Random.Next(maxLength);
            var arrayElement = context.TargetType.GetElementType();
            var array = Array.CreateInstance(arrayElement, arrayLength);

            for (var i = 0; i < arrayLength; i++)
            {
                var elementContext = context.Provider.CreateContext(context, i, arrayElement, context.Attributes);
                var elementValue = context.Provider.Generate(elementContext);
                array.SetValue(elementValue, i);
            }

            return array;
        }
    }
}
