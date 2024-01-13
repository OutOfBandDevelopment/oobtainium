using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace OoBDev.Oobtainium.Tests.IO;

[TestClass]
public class PathNavigatorFactoryTests
{
    public TestContext TestContext { get; set; }

    [TestMethod, TestCategory(TestCategories.DevLocal)]
    public void ToNavigableTest()
    {
        var di = new DirectoryInfo("../../../../");
        var xpath = di.ToNavigable().CreateNavigator();
        TestContext.AddResult(xpath);
    }
}
