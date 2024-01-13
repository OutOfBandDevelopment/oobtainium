using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.Codecs;
using OoBDev.Oobtainium.TestUtilities;

namespace OoBDev.Oobtainium.Tests.Codecs;

[TestClass]
public class MorseCodeTests
{
    public TestContext TestContext { get; set; }

    [DataTestMethod]
    [DataRow("Hello, World!", ".... . .-.. .-.. ---  .-- --- .-. .-.. -..")]
    [DataRow("hello world", ".... . .-.. .-.. ---  .-- --- .-. .-.. -..")]
    [DataRow("abcdefghijklmnopqrstuvwxyz1234567890", ".- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --.. .---- ..--- ...-- ....- ..... -.... --... ---.. ----. -----")]
    [TestMethod, TestCategory(TestCategories.Unit)]
    public void EncodeTest(string message, string expected)
    {
        var result = new MorseCode().Encode(message);
        TestContext.WriteLine($"{message} -> {result}");
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow(".... . .-.. .-.. ---  .-- --- .-. .-.. -..", "HELLO WORLD")]
    [DataRow(".- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --..  .---- ..--- ...-- ....- ..... -.... --... ---.. ----. -----", "ABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890")]
    [TestMethod, TestCategory(TestCategories.Unit)]
    public void DecodeTest(string message, string expected)
    {
        var result = new MorseCode().Decode(message);
        TestContext.WriteLine($"{message} -> {result}");
        Assert.AreEqual(expected, result);
    }
}
