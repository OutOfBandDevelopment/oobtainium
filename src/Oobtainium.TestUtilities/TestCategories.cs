namespace OoBDev.Oobtainium.TestUtilities;

public static class TestCategories
{
    public const string Unit = nameof(Unit);
    public const string Integration = nameof(Integration);
    public const string DevLocal = nameof(DevLocal);
    public const string Reports = nameof(Reports);
    public const string Simulate = nameof(Simulate);
    public const string PoC = nameof(PoC);

    public static class Feature
    {
        public const string Logging = nameof(Logging);
        public const string CallRecording = nameof(CallRecording);
        public const string Redirection = nameof(Redirection);
        public const string Reflection = nameof(Reflection);
    }
}
