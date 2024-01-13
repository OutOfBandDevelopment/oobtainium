using HidSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.TestUtilities;
using System.Linq;
using System.Text;

namespace OoBDev.Oobtainium.IO.Tests;

[TestClass]
public class SampleUsageTests
{
    public TestContext TestContext { get; set; }

    [TestMethod, TestCategory(TestCategories.DevLocal)]
    public void ListDevicesTests()
    {
        var devices = DeviceList.Local
                               .GetAllDevices()
                               .OfType<HidDevice>();

        foreach (var device in devices)
        {
            TestContext.WriteLine(device.ToString());
        }
    }

    [TestMethod, TestCategory(TestCategories.DevLocal)]
    public void ListDevicesAllTests()
    {
        var devices = DeviceList.Local
                               .GetAllDevices()
                               ;

        foreach (var device in devices)
        {
            TestContext.WriteLine($@"""{device.DevicePath}"" {{{device}}}");
        }
    }

    [DataTestMethod, TestCategory(TestCategories.DevLocal)]
    [DataRow(4451, 512, DisplayName = "DeLorme Publishing DeLorme USB Earthmate")]
    [DataRow(0x10cf, 0x5500, 0xfff8, DisplayName = "Velleman K8055")]
    [DataRow(0xfc02, 0x0101, DisplayName = "Midi Controller")]
    //[DataRow(0x04d8, 0xf848, DisplayName = "BLL Company ApS BLL Lamp")]
    public void ListenToDeviceTests(int vendorId, int productId, int productMask = 0xffff)
    {
        var devices = DeviceList.Local
                               .GetAllDevices()
                               .OfType<HidDevice>();
        var selectedDevices = devices.Where(d => d.VendorID == vendorId && (d.ProductID & productMask) == productId);

        foreach (var device in selectedDevices)
        {
            TestContext.WriteLine(device.ToString());

            if (device.TryOpen(out var stream))
            {
                if (stream.CanRead)
                {
                    try
                    {
                        stream.ReadTimeout = 1500;

                        for (var rpt = 0; rpt < 5; rpt++)
                        {
                            var report = stream.Read();
                            TestContext.WriteLine($"\t{rpt}: {report.ToHexString()} = {Encoding.UTF8.GetString(report)}");
                        }
                    }
                    finally
                    {
                        stream.Dispose();
                    }
                }
                else
                {
                    TestContext.WriteLine($"\t{-1}: Can't read");
                }
            }
        }
    }
}
