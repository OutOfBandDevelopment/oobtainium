using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.ComponentModel;
using OoBDev.Oobtainium.Reflection;
using OoBDev.Oobtainium.Tests.TestTargets;
using OoBDev.Oobtainium.TestUtilities;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace OoBDev.Oobtainium.Tests.ProofOfConcepts;

[TestClass]
public class DispatchProxyManipulation
{
    public required TestContext TestContext { get; set; }

    public class Proxy<T> : WrappedDispatchProxy<T>
    {
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            Debug.WriteLine($"\t:> {typeof(T)}::{targetMethod}");
            if (targetMethod.DeclaringType.IsInstanceOfType(Instance))
            {
                return targetMethod.Invoke(Instance, args);
            }
            else
            {
                return targetMethod.ReturnType.GetDefaultValue();
            }
        }
    }

    [TestMethod, TestCategory(TestCategories.PoC)]
    [TestCategory(TestCategories.Feature.Reflection)]
    public void Stack_Interfaces_On_DispatchProxy()
    {
        var proxy1 = DispatchProxy.Create<ITargetInterface, Proxy<ITargetInterface>>();
        Assert.IsInstanceOfType(proxy1, typeof(ITargetInterface));

        object proxy2 = proxy1.AddInterface<IAnotherInterface, Proxy<IAnotherInterface>>();
        object proxy3 = proxy2.AddInterface<IEmptyInterface, Proxy<IEmptyInterface>>();

        var c1 = (IAnotherInterface)proxy3;
        TestContext.WriteLine($"\"{c1.DoWork("hi!")}\"");
        var c2 = (ITargetInterface)proxy3;
        TestContext.WriteLine($"\"{c2.ReturnValue()}\"");
        var c3 = (IEmptyInterface)proxy3;

        Assert.IsInstanceOfType(proxy3, typeof(ITargetInterface));
        Assert.IsInstanceOfType(proxy3, typeof(IAnotherInterface));
        Assert.IsInstanceOfType(proxy3, typeof(IEmptyInterface));

        TestContext.WriteLine($"Triple Wrapped: {c3}");

        foreach (var @interface in c3.GetType().GetInterfaces())
        {
            TestContext.WriteLine($"Interface: {@interface}");

            var attributes = TypeDescriptor.GetAttributes(@interface);

            foreach (var attribute in attributes)
            {
                TestContext.WriteLine($"\tAttribute: {attribute}");
            }
        }
    }

    [TestMethod, TestCategory(TestCategories.PoC)]
    [TestCategory(TestCategories.Feature.Reflection)]
    public void Stack_Interfaces_On_Class()
    {
        var proxy1 = new ClassWithInterface();

        Assert.IsInstanceOfType(proxy1, typeof(IAnotherInterface));

        object proxy2 = proxy1.AddInterface<ITargetInterface, Proxy<ITargetInterface>>();
        object proxy3 = proxy2.AddInterface<IEmptyInterface, Proxy<IEmptyInterface>>();

        var c1 = (IAnotherInterface)proxy3;
        //this.TestContext.WriteLine($"\"{c1.DoWork("hi!")}\"");
        var c2 = (ITargetInterface)proxy3;
        TestContext.WriteLine($"\"{c2.ReturnValue()}\"");
        var c3 = (IEmptyInterface)proxy3;

        Assert.IsInstanceOfType(proxy3, typeof(ITargetInterface));
        Assert.IsInstanceOfType(proxy3, typeof(IAnotherInterface));
        Assert.IsInstanceOfType(proxy3, typeof(IEmptyInterface));

        TestContext.WriteLine($"Triple Wrapped: {c3}");

        foreach (var @interface in c3.GetType().GetInterfaces())
        {
            TestContext.WriteLine($"Interface: {@interface}");

            var attributes = TypeDescriptor.GetAttributes(@interface);

            foreach (var attribute in attributes)
            {
                TestContext.WriteLine($"\tAttribute: {attribute}");
            }
        }
    }
}
