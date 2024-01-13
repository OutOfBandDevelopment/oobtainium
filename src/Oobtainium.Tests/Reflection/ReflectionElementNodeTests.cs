using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace OoBDev.Oobtainium.Tests.Reflection;

[TestClass]
public class ReflectionElementNodeTests
{
    public TestContext TestContext { get; set; }

    private MockRepository mockRepository;

    [TestInitialize]
    public void TestInitialize()
    {
        mockRepository = new MockRepository(MockBehavior.Strict);
    }

    private ReflectionElementNodeBuilder CreateReflectionElementNode(object testData, bool excludeNamespace = false) =>
        new(testData, excludeNamespace);

    [TestMethod, TestCategory(TestCategories.DevLocal)]
    [TestCategory(TestCategories.Unit)]
    public void ReflectionElementNodeTest()
    {
        // Stage
        var testData = new
        {
            Hello = "World!",
            DateTime = DateTime.Now,
            DateTimeOffset = DateTimeOffset.Now,
            DateTimeOffset.Now.TimeOfDay,
            Integer = 123,
            Decimal = 123.456m,
            Bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 },
            Nested = new
            {
                Other = "Property1",
            },
            Array = new[]
            {
                "test",
                "test2"
            },
            ArrayIntegers = new[] { 1, 2, 3, 4, 5, 6 }
        };

        // Mock

        // Test
        var reflectionElementNode = CreateReflectionElementNode(testData, true).Build();
        var nav = reflectionElementNode.ToNavigable().CreateNavigator();

        if (nav != null)
            TestContext.AddResult(nav);

        // Assert
        Assert.IsFalse(string.IsNullOrWhiteSpace(nav?.OuterXml));

        // Verify
        mockRepository.VerifyAll();
    }
}
