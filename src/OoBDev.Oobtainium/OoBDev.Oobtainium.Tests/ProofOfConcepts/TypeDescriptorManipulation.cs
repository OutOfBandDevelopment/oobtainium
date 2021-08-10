using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.Tests.TestTargets;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OoBDev.Oobtainium.Tests.ProofOfConcepts
{
    [TestClass]
    public class TypeDescriptorManipulation
    {
        public TestContext TestContext { get; set; }

        [TestMethod, TestCategory(TestCategories.PoC)]
        [TestCategory(TestCategories.Feature.Reflection)]
        public void Get_Dynamically_Added_Attributes()
        {
            var target = typeof(ITargetInterface);

            //show attribute doesn't exist
            var attributes = TypeDescriptor.GetAttributes(target).OfType<DisplayAttribute>();
            Assert.IsFalse(attributes.Any());

            // add attribute to type
            _ = TypeDescriptor.AddAttributes(typeof(ITargetInterface), new DisplayAttribute() { Name = "Test" });
            TypeDescriptor.Refresh(target);

            //ensure attribute now exists
            var attributes2 = TypeDescriptor.GetAttributes(target).OfType<DisplayAttribute>();
            Assert.IsTrue(attributes2.Any());
        }

        [TestMethod, TestCategory(TestCategories.PoC)]
        [TestCategory(TestCategories.Feature.Reflection)]
        public void Get_Static_Attributes()
        {
            var target = typeof(ITargetInterface);

            var attributes = TypeDescriptor.GetAttributes(target).OfType<LookupAttribute>();

            Assert.IsTrue(attributes.Any());
        }
    }
}
