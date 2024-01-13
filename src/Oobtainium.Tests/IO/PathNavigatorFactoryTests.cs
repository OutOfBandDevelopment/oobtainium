using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.IO;
using OoBDev.Oobtainium.TestUtilities;
using OoBDev.Oobtainium.Xml.XPath;
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
