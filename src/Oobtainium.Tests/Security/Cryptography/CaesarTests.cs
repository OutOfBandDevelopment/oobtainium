﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.Security.Cryptography;
using OoBDev.Oobtainium.TestUtilities;

namespace OoBDev.Oobtainium.Tests.Security.Cryptography;

[TestClass]
public class CaesarTests
{
    public TestContext TestContext { get; set; }

    [DataTestMethod]
    [DataRow("Hello World", 'H', "Olssv Dvysk")]
    [DataRow("Hello, World", 'H', "Olssv, Dvysk")]
    [DataRow("hello, world", 'h', "olssv, dvysk")]
    [DataRow("hello world", 'C', "jgnnq yqtnf")]
    [TestMethod, TestCategory(TestCategories.Unit)]
    public void EncodeTest(string message, char key, string expected)
    {
        var result = new Caesar().Encode(message, key);
        TestContext.WriteLine($"{message} -> {result}");
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("Olssv Dvysk", 'H', "Hello World")]
    [DataRow("Olssv, Dvysk", 'H', "Hello, World")]
    [DataRow("olssv, dvysk", 'h', "hello, world")]
    [DataRow("jgnnq yqtnf", 'C', "hello world")]
    [TestMethod, TestCategory(TestCategories.Unit)]
    public void DecodeTest(string message, char key, string expected)
    {
        var result = new Caesar().Decode(message, key);
        TestContext.WriteLine($"{message} -> {result}");
        Assert.AreEqual(expected, result);
    }
}
