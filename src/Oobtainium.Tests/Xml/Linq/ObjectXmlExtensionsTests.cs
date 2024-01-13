﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.TestUtilities;
using OoBDev.Oobtainium.Xml.Linq;
using System;

namespace OoBDev.Oobtainium.Tests.Xml.Linq;

[TestClass]
public class ObjectXmlExtensionsTests
{
    public TestContext TestContext { get; set; }

    [TestMethod, TestCategory(TestCategories.DevLocal)]
    public void AsXElementTest()
    {
        var testData = new
        {
            hello = "world",
            nested = new
            {
                another = 1,
                other = DateTimeOffset.Now,
                DeeperStill = new[]
                {
                    new {obj1=1 },
                    new {obj1=2 },
                    new {obj1=3 },
                    new {obj1=4 },
                    new {obj1=5 },
                },
            },
        };

        var result = ObjectXmlExtensions.AsXElement(testData);
        if (result != null)
            TestContext.AddResult(result);
    }
}
