namespace OoBDev.Oobtainium.Tests;

public static class TestCategories
{
    public const string Unit = nameof(Unit);

    /// <summary>
    /// Simulations are full stack tests. Similar to integration except external interfaces are replace with redirections.
    /// </summary>
    public const string Simulate = nameof(Simulate);

    /// <summary>
    /// full static tests including actual external invocations.
    /// </summary>
    public const string Integration = nameof(Integration);

    /// <summary>
    /// Proof of Concept: Tech demos and ideas
    /// </summary>
    public const string PoC = nameof(PoC);

    public static class Feature
    {
        public const string Logging = nameof(Logging);
        public const string CallRecording = nameof(CallRecording);
        public const string Redirection = nameof(Redirection);
        public const string Reflection = nameof(Reflection);
    }
}
