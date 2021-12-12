using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.Generation;
using OoBDev.Oobtainium.Tests.TestTargets;
using System;
using System.Text.Json;

namespace OoBDev.Oobtainium.Tests.Generation
{
    [TestClass]
    public class ProcedualGenerationProviderTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void GenerateTest()
        {
            // Arrange
            var provider = new ProcedualGenerationProviderBuilder().Build();

            // Act
            for (var x = 0; x < 2; x++)
            {
                var context = provider.CreateContext(typeof(ModelWithProperties));
                for (var y = 0; y < 2; y++)
                {
                    var result = provider.Generate(context);
                    var json = JsonSerializer.Serialize(result);

                    TestContext.WriteLine($"{(context.TargetType,  x, y)} = {json}");
                }
            }

            for (var x = 0; x < 2; x++)
            {
                var context = provider.CreateContext(typeof(ModelWithProperties2));
                for (var y = 0; y < 2; y++)
                {
                    var result = provider.Generate(context);
                    var json = JsonSerializer.Serialize(result);

                    TestContext.WriteLine($"{(context.TargetType, x, y)} = {json}");
                }
            }

            for (var x = 0; x < 2; x++)
            {
                var context = provider.CreateContext(typeof(ModelWithProperties3));
                for (var y = 0; y < 2; y++)
                {
                    var result = provider.Generate(context);
                    var json = JsonSerializer.Serialize(result);

                    TestContext.WriteLine($"{(context.TargetType, x, y)} = {json}");
                }
            }

            // Assert
        }
    }
}
