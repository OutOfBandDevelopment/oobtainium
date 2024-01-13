using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.Collections;
using OoBDev.Oobtainium.TestUtilities;
using System.Text;

namespace OoBDev.Oobtainium.Tests.Collections;

[TestClass]
public class ReversableEnumeratorTests
{
    public TestContext TestContext { get; set; }

    [TestMethod, TestCategory(TestCategories.DevLocal)]
    public void MoveNextMovePreviousTest()
    {
        var set = new object[] { 1, 2, 3, 4, 5 }.GetReversibleEnumerator();

        var sb = new StringBuilder();
        sb.AppendLine("MoveNext>");
        while (set.MoveNext())
        {
            sb.Append(set.Current ?? "!NULL!").Append(';');
        }
        sb.AppendLine();
        sb.AppendLine("MovePrevious>");
        while (set.MovePrevious())
        {
            sb.Append(set.Current ?? "!NULL!").Append(';');
        }
        sb.AppendLine();
        sb.AppendLine("MoveNext>");
        while (set.MoveNext())
        {
            sb.Append(set.Current ?? "!NULL!").Append(';');
        }

        sb.AppendLine();
        sb.AppendLine("Reset>");
        set.Reset();

        sb.AppendLine("MoveNext>");
        while (set.MoveNext())
        {
            sb.Append(set.Current ?? "!NULL!").Append(';');
        }
        sb.AppendLine();
        sb.AppendLine("MovePrevious>");
        while (set.MovePrevious())
        {
            sb.Append(set.Current ?? "!NULL!").Append(';');
        }
        sb.AppendLine();
        sb.AppendLine("MoveNext>");
        while (set.MoveNext())
        {
            sb.Append(set.Current ?? "!NULL!").Append(';');
        }

        TestContext.WriteLine(sb.ToString());
    }
}
