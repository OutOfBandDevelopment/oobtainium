namespace OoBDev.Oobtainium.Generation
{
    public class ProcedualGenerationProviderBuilder : IProcedualGenerationProviderBuilder
    {
        public IProcedualGenerationProvider Build()
            => new ProcedualGenerationProvider(
                new ProcedualGenerationContextBuilder(
                    new ProcedualGenerationSeedGenerator()
                    )
                );
    }
}
