using BinaryDataDecoders.Yaml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.TestUtilities;
using System.IO;

namespace OoBDev.Oobtainium.Text.Tests.Yaml;

[TestClass]
public class YamlNavigatorTests
{
    public TestContext TestContext { get; set; }

    [DataTestMethod, TestCategory(TestCategories.DevLocal)]
    [DataRow("Example.yml")]
    [DataRow("dotnet-core.yml")]
    //[DataRow("codeql-analysis.yml")]
    public void ToNavigableTest(string resourceName)
    {
        var nav = new YamlNavigator();
        var stream = this.GetResourceStream(resourceName);
        var xpath = nav.ToNavigable(stream).CreateNavigator();
        TestContext.AddResult(xpath, Path.ChangeExtension(resourceName, ".xml"));
    }
}
