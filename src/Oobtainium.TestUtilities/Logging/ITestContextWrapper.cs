using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OoBDev.Oobtainium.TestUtilities.Logging;

public interface ITestContextWrapper
{
    TestContext Context { get; }
}
