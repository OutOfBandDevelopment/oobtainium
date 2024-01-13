using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OoBDev.Oobtainium.TestUtilities.Logging;

public class TestContextWrapper(TestContext context) : ITestContextWrapper
{
    public TestContext Context { get; } = context;
}
