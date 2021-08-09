using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.Tests.TestTargets;
using System.ComponentModel;
using System.Reflection;
using OoBDev.Oobtainium.Reflection;
using static OoBDev.Oobtainium.Tests.ProofOfConcepts.DispatchProxyManipulation;

namespace OoBDev.Oobtainium.Tests.ProofOfConcepts
{
    [TestClass]
    public class DispatchProxyManipulation
    {
        public TestContext TestContext { get; set; }

        public class Proxy<T> : WrappedDispatchProxy<T>
        {
            protected override object Invoke(MethodInfo targetMethod, object[] args)
            {
                throw new System.NotImplementedException();
            }
        }

        [TestMethod]
        public void Stack_Interfaces_On_DispatchProxy()
        {
            var proxy1 = DispatchProxy.Create<ITargetInterface, Proxy<ITargetInterface>>();
            Assert.IsInstanceOfType(proxy1, typeof(ITargetInterface));

            object proxy2 = proxy1.AddInterface<IAnotherInterface>(typeof(Proxy<>));
            object proxy3 = proxy2.AddInterface<IEmptyInterface>(typeof(Proxy<>));

            var c1 = (IAnotherInterface)proxy3;
            this.TestContext.WriteLine($"\"{c1.DoWork("hi!")}\"");
            var c2 = (ITargetInterface)proxy3;
            this.TestContext.WriteLine($"\"{c2.ReturnValue()}\"");
            var c3 = (IEmptyInterface)proxy3;

            Assert.IsInstanceOfType(proxy3, typeof(ITargetInterface));
            Assert.IsInstanceOfType(proxy3, typeof(IAnotherInterface));
            Assert.IsInstanceOfType(proxy3, typeof(IEmptyInterface));

            this.TestContext.WriteLine($"Triple Wrapped: {c3}");

            foreach (var @interface in c3.GetType().GetInterfaces())
            {
                this.TestContext.WriteLine($"Interface: {@interface}");

                var attributes = TypeDescriptor.GetAttributes(@interface);

                foreach (var attribute in attributes)
                {
                    this.TestContext.WriteLine($"\tAttribute: {attribute}");
                }
            }
        }

        [TestMethod]
        public void Stack_Interfaces_On_Class()
        {
            var proxy1 = new ClassWithInterface();

            Assert.IsInstanceOfType(proxy1, typeof(IAnotherInterface));

            object proxy2 = proxy1.AddInterface<ITargetInterface>(typeof(Proxy<>));
            object proxy3 = proxy2.AddInterface<IEmptyInterface>(typeof(Proxy<>));

            var c1 = (IAnotherInterface)proxy3;
            this.TestContext.WriteLine($"\"{c1.DoWork("hi!")}\"");
            var c2 = (ITargetInterface)proxy3;
            this.TestContext.WriteLine($"\"{c2.ReturnValue()}\"");
            var c3 = (IEmptyInterface)proxy3;

            Assert.IsInstanceOfType(proxy3, typeof(ITargetInterface));
            Assert.IsInstanceOfType(proxy3, typeof(IAnotherInterface));
            Assert.IsInstanceOfType(proxy3, typeof(IEmptyInterface));

            this.TestContext.WriteLine($"Triple Wrapped: {c3}");

            foreach (var @interface in c3.GetType().GetInterfaces())
            {
                this.TestContext.WriteLine($"Interface: {@interface}");

                var attributes = TypeDescriptor.GetAttributes(@interface);

                foreach (var attribute in attributes)
                {
                    this.TestContext.WriteLine($"\tAttribute: {attribute}");
                }
            }
        }
    }
}
