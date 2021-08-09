using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.Tests.TestTargets;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace OoBDev.Oobtainium.Tests.ProofOfConcepts
{
    [TestClass]
    public class TypeBuilderManipulation
    {
        public TestContext TestContext { get; set; }

        [TestMethod, TestCategory(TestCategories.PoC)]
        public void Add_Interface_To_Existing_Type()
        {
            var existingType =typeof(ClassWithoutInterfaces);
            var interfaceToAdd = typeof(IEmptyInterface);

            // https://blog.wedport.co.uk/2020/06/10/generating-c-net-core-classes-at-runtime/
            var newTypeName = $"{existingType}&{interfaceToAdd}";

            var assemblyName = new AssemblyName(newTypeName);
            var dynamicAssembly = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var dynamicModule = dynamicAssembly.DefineDynamicModule("Main");
            var dynamicType = dynamicModule.DefineType(newTypeName,
                    TypeAttributes.Public |
                    TypeAttributes.Class |
                    TypeAttributes.AutoClass |
                    TypeAttributes.AnsiClass |
                    TypeAttributes.BeforeFieldInit |
                    TypeAttributes.AutoLayout,
                    existingType
                    );

            //add any implementations from new interfaces here

            dynamicType.AddInterfaceImplementation(interfaceToAdd);

            var newType = dynamicType.CreateType();
            var newInstance = Activator.CreateInstance(newType);

            Assert.IsInstanceOfType(newInstance, existingType);
            Assert.IsInstanceOfType(newInstance, interfaceToAdd);
        }
    }
}
