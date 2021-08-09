using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.Tests.TestTargets;
using System;
using System.Threading.Tasks;

namespace OoBDev.Oobtainium.Tests
{
    [TestClass]
    public class GeneralTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public async Task GeneralTest()
        {
            var services = new ServiceCollection()
                .AddLogging(logging =>
                    logging.AddDebug()
                           .SetMinimumLevel(LogLevel.Debug)
                    )

                //Setup container for oobtainium
                .AddOobtainium()
                //.AddScoped<ICallRecorder, CallRecorder>()
                //.AddScoped<ICallBindingStore, CallBindingStore>()
                //.AddTransient<ICaptureProxyFactory, CaptureProxyFactory>()
                //.AddTransient<ICallBinder, CallBinder>()
                //.AddTransient<ICallHandler, CallHandler>()

                //setup mocked interface in IOC
                .AddTransient(sp => sp.GetRequiredService<ICaptureProxyFactory>().Create<IAnotherInterface>())

                ;
            var sp = services.BuildServiceProvider();

            var factory = sp.GetRequiredService<ICaptureProxyFactory>();

            // configure binding interceptions
            var binder = sp.GetRequiredService<ICallBinder>()
                    .Build<ITargetInterface>()
                        .Bind(a => a.VoidReturn(), () => TestContext.WriteLine("Do Work"))
                        .Bind(a => a.VoidReturnAsync(), async args =>
                        {
                            TestContext.WriteLine("Delay");
                            await Task.Delay(1000);
                            TestContext.WriteLine("Done");
                        })
                        .Bind(a => a.InvokeAsync(new { Test = "" }), p => new { Test = p[0].ToString() ?? "" })
                        .Bind(a => a.VoidReturnWithGenericInput(new { Other = "" }), () => Task.FromResult(new { Other = "" }))
                        .Bind(a => a.ReturnValue(), () => Task.FromResult(Guid.NewGuid()))
                    .Build<IAnotherInterface>()
                    ;

            //create proxy 
            var instance = factory.Create<ITargetInterface>();

            TestContext.WriteLine($"Out> {instance.ReturnValue()}");
            instance.VoidReturn();
            await instance.VoidReturnAsync();
            instance[456] = "Hi!";
            TestContext.WriteLine($"Out> {instance[456]}");
            instance[456] = "xyz";
            TestContext.WriteLine($"Out> {instance[456]}");
            await instance.VoidReturnWithInputAsync("HI!");
            await instance.VoidReturnWithGenericInputAsync(234);
            TestContext.WriteLine($"Out> {await instance.InvokeAsync()}");
            TestContext.WriteLine($"Out> {await instance.InvokeAsync("Hello!!")}");
            TestContext.WriteLine($"Out> {await instance.InvokeAsync(345)}");
            await instance.VoidReturnAsync();
            await instance.InvokeAsync(new { Test = "Hello" });
            instance.VoidReturnWithGenericInput(new { Other = "hello" });

            var another = sp.GetRequiredService<IAnotherInterface>();
            this.TestContext.WriteLine($"{another.DoWork("hello world!")}");
            this.TestContext.WriteLine($"{await another.DoWork2("hello world!")}");

            //retrieve call recorder
            var captured = sp.GetRequiredService<ICallRecorder>();
            foreach (var recoding in captured)
            {
                TestContext.WriteLine($"> {recoding}");
            }
            /*
                > OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.String ReturnValue()  => 295b1cf5-05b3-4e21-a27b-2fcb82d8ef74
                > OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::Void VoidReturn()  
                > OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.Threading.Tasks.Task VoidReturnAsync()  
                > OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::Void set_Item(Int32, System.String) [456;Hi!] 
                > OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.String get_Item(Int32) [456] => Hi!
                > OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::Void set_Item(Int32, System.String) [456;xyz] 
                > OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.String get_Item(Int32) [456] => xyz
                > OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.Threading.Tasks.Task VoidReturnWithInputAsync(System.String) [HI!] 
                > OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.Threading.Tasks.Task VoidReturnWithGenericInputAsync[Int32](Int32) [234] 
                > OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.Threading.Tasks.Task`1[System.Object] InvokeAsync()  
                > OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.Threading.Tasks.Task`1[System.String] InvokeAsync[String](System.String) [Hello!!] 
                > OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.Threading.Tasks.Task`1[System.Int32] InvokeAsync[Int32](Int32) [345] 
                > OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.Threading.Tasks.Task VoidReturnAsync()  
                > OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.Threading.Tasks.Task`1[<>f__AnonymousType0`1[System.String]] InvokeAsync[<>f__AnonymousType0`1](<>f__AnonymousType0`1[System.String]) [{ Test = Hello }] => { Test = { Test = Hello } }
                > OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::Void VoidReturnWithGenericInput[<>f__AnonymousType1`1](<>f__AnonymousType1`1[System.String]) [{ Other = hello }] 
                > OoBDev.Oobtainium.Tests.TestTargets.IAnotherInterface::Int32 DoWork(System.String) [hello world!] 
                > OoBDev.Oobtainium.Tests.TestTargets.IAnotherInterface::System.Threading.Tasks.Task`1[System.Int32] DoWork2(System.String) [hello world!]
            */
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void SimpleTest()
        {
            var factory = new CaptureProxyFactory();

            //mock out method response
            var bindings = new CallBinder()
                .Build<ITargetInterface>()
                    .Bind(a => a.ReturnValue(), () => "Hello World")
                    ;

            //create instance with handler 
            var instance = factory.Create<ITargetInterface>(handler: new CallHandler(bindings.Store));

            //test function
            var result = instance.ReturnValue();

            //assert
            Assert.AreEqual("Hello World", result);

            //// TODO: fix this... in process of moving
            ////get recording from proxy instance
            //var recorder = ((IHaveCallRecorder)instance).Recorder;
            //foreach (var recoding in recorder)
            //    this.TestContext.WriteLine(recoding?.ToString());
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void OnAgainOffAgainTest()
        {
            var factory = new CaptureProxyFactory();

            //create instance with handler 
            var instance = factory.Create<ITargetInterface>();

            // not bound

            var builder = ((IHaveCallBindingStore)instance).Store.Build<ITargetInterface>();

            //test function
            Assert.IsNull(instance.ReturnValue());

            builder.Bind(a => a.ReturnValue(), () => "Hello World");
            Assert.AreEqual("Hello World", instance.ReturnValue());

            builder.Bind(a => a.ReturnValue(), () => "Hello World!");
            Assert.AreEqual("Hello World!", instance.ReturnValue());

            builder.Remove(a => a.ReturnValue());
            Assert.IsNull(instance.ReturnValue());

            // TODO: fix this... in process of moving
            ////get recording from proxy instance
            //var recorder = ((IHaveCallRecorder)instance).Recorder;
            //foreach (var recoding in recorder)
            //    this.TestContext.WriteLine(recoding?.ToString());

            /*
            ﻿ OnAgainOffAgainTest
               Source: GeneralTests.cs line 133
               Duration: 37 ms

              Standard Output: 
                TestContext Messages:
                OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.String ReturnValue()  
                OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.String ReturnValue()  => Hello World
                OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.String ReturnValue()  => Hello World!
                OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.String ReturnValue()
            */
        }
    }
}