﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.TestUtilities;
using System;
using System.IO;
using System.Linq;
using System.Text;
using static OoBDev.Oobtainium.IO.Bytes;

namespace OoBDev.Oobtainium.Devices.Tests.ElectronicScoringMachines.Fencing.SaintGeorge;

[TestClass]
public class SqTestDataExtractor
{
    public TestContext TestContext { get; set; }

    [TestMethod, TestCategory(TestCategories.DevLocal)]
    [Ignore]
    public void TestDataExtractor()
    {
        var path = @"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ElectronicScoringMachines.Fencing\SaintGeorge\outfile.bin";
        var data = File.ReadAllBytes(path);
        var memory = data.AsMemory();

        var chunks = memory.Split(delimiter: Soh, option: DelimiterOptions.Carry);

        var segments = (from c in chunks
                        select c.ToArray().ToHexString(",0x"))
                       .Distinct()
                       .OrderBy(i => i)
                       .Aggregate(new StringBuilder(), (sb, v) => sb.Append("0x").Append(v).AppendLine())
                       .ToString();
        TestContext.WriteLine(segments);

    }
}
