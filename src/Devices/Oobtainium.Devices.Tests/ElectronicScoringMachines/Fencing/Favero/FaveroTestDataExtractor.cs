using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.Devices.ElectronicScoringMachines.Fencing.Favero;
using OoBDev.Oobtainium.TestUtilities;
using System.IO;
using System.Linq;

namespace OoBDev.Oobtainium.Devices.Tests.ElectronicScoringMachines.Fencing.Favero;

[TestClass]
public class FaveroTestDataExtractor
{
    public TestContext TestContext { get; set; }

    [TestMethod, TestCategory(TestCategories.DevLocal)]
    [Ignore]
    public void TestDataExtractor()
    {
        var path = @"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ElectronicScoringMachines.Fencing\Favero\RawData.txt";

        var chunks = File.ReadAllText(path)
                         .Where(c => c >= '0' && c <= '9' || c >= 'A' && c <= 'F' || c >= 'a' && c <= 'f')
                         .AsMemory()
                         .BytesFromHexString()
                         .Split(0xff, DelimiterOptions.Carry)
                         ;

        //var segments = (from c in chunks
        //                select c.ToArray().ToHexString(",0x"))
        //               .Distinct()
        //               .OrderBy(i => i)
        //               .Aggregate(new StringBuilder(), (sb, v) => sb.Append("0x").Append(v).AppendLine())
        //               .ToString();
        // this.TestContext.WriteLine(segments);

        var parser = new FaveroStateParser();
        foreach (var c in chunks.Distinct())
        {
            try
            {
                var state = parser.Parse(c.Span);
                TestContext.WriteLine(state.ToString());
            }
            catch
            {
                TestContext.WriteLine($"ERROR Decoding {c.ToArray().ToHexString()}");
            }
        }
    }
}
