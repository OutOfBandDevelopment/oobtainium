namespace OoBDev.Oobtainium.Generation
{
    public interface IGenerateObject : IHavePriority
    {
        object? GenerateValue(IProcedualGenerationContext context);
        bool CanGenerateValue(IProcedualGenerationContext context);
    }
}
