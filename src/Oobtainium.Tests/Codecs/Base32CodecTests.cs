using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.Codecs;
using OoBDev.Oobtainium.TestUtilities;
using System.Text;

namespace OoBDev.Oobtainium.Tests.Codecs;


[TestClass]
public class Base32CodecTests
{
    [TestMethod, TestCategory(TestCategories.Unit)]
    public void DecodeTest()
    {
        var tests = new[]{
            new {encoded="", decoded = "",},
            new {encoded="MY======", decoded ="f",},
            new {encoded="MZXQ====", decoded = "fo",},
            new {encoded="MZXW6===", decoded = "foo",},
            new {encoded="MZXW6YQ=", decoded = "foob",},
            new {encoded="MZXW6YTB", decoded = "fooba",},
            new {encoded="MZXW6YTBOI======", decoded = "foobar",},
        };

        var encoding = new Base32Codec();
        foreach (var test in tests)
        {
            var bytes = encoding.Decode(test.encoded);
            var decoded = Encoding.ASCII.GetString(bytes);
            Assert.AreEqual(test.decoded, decoded);
        }
    }

    [TestMethod, TestCategory(TestCategories.Unit)]
    public void EncodeTest()
    {
        var tests = new[]{
            new {encoded="", decoded = "",},
            new {encoded="MY======", decoded ="f",},
            new {encoded="MZXQ====", decoded = "fo",},
            new {encoded="MZXW6===", decoded = "foo",},
            new {encoded="MZXW6YQ=", decoded = "foob",},
            new {encoded="MZXW6YTB", decoded = "fooba",},
            new {encoded="MZXW6YTBOI======", decoded = "foobar",},
        };

        var encoding = new Base32Codec();
        foreach (var test in tests)
        {
            var buffer = Encoding.ASCII.GetBytes(test.decoded);
            var encoded = encoding.Encode(buffer);
            Assert.AreEqual(test.encoded, encoded);
        }
    }
}
