# OoBtainium

## Summary

Out-of-Band Development presents Oobtainium.  This is a simple mocking framework that allows for interception and call capture.

## Examples 

Simplified example

```csharp
    [TestMethod, TestCategory("Unit")]
    public void SimpleTest()
    {
        var factory = new CaptureProxyFactory();

        //mock out method response
        var bindings = new CallBinder()
            .Register<ITargetInterface>()
                .Bind(a => a.ReturnValue(), () => "Hello World")
                ;

        //create instance with handler 
        var instance = factory.Create<ITargetInterface>(handler: bindings.ToHandler());

        //test function
        var result = instance.ReturnValue();

        //assert
        Assert.AreEqual("Hello World", result);

        //get recording from proxy instance
        var recorder = ((IHaveCallRecorder)instance).Recorder;
        foreach (var recoding in recorder)
            this.TestContext.WriteLine(recoding?.ToString());

        /*
        ﻿ SimpleTest
            Source: GeneralTests.cs line 106
            Duration: 124 ms

            Standard Output: 
            TestContext Messages:
            OoBDev.Oobtainium.Tests.TestTargets.ITargetInterface::System.String ReturnValue()  => Hello World
        */
    }
```

### 

## Build Status

[![.NET Core](https://github.com/OutOfBandDevelopment/oobtainium/workflows/.NET%20Core/badge.svg)](https://github.com/OutOfBandDevelopment/oobtainium)
[![.NET Core](https://img.shields.io/github/v/tag/OutOfBandDevelopment/oobtainium)](https://github.com/OutOfBandDevelopment/oobtainium)
[![NuGet](https://img.shields.io/nuget/v/OoBDev.Oobtainium.Abstractions)](https://www.nuget.org/packages/OoBDev.Oobtainium.Abstractions)
[![NuGet](https://img.shields.io/github/license/OutOfBandDevelopment/oobtainium)](https://github.com/OutOfBandDevelopment/oobtainium/blob/master/LICENSE)

![NuGet](https://img.shields.io/github/languages/code-size/OutOfBandDevelopment/oobtainium)
![NuGet](https://img.shields.io/github/repo-size/OutOfBandDevelopment/oobtainium)
![NuGet](https://img.shields.io/tokei/lines/github/OutOfBandDevelopment/oobtainium)
![NuGet](https://img.shields.io/nuget/dt/OoBDev.Oobtainium.Abstractions)


![NuGet](https://img.shields.io/github/issues/OutOfBandDevelopment/oobtainium)
![NuGet](https://img.shields.io/github/issues-pr/OutOfBandDevelopment/oobtainium)
![NuGet](https://img.shields.io/github/last-commit/OutOfBandDevelopment/oobtainium)


[![NuGet](https://img.shields.io/github/followers/mwwhited?style=social)](https://github.com/mwwhited/)
[![NuGet](https://img.shields.io/github/forks/OutOfBandDevelopment/oobtainium?label=Fork&style=social)](https://github.com/OutOfBandDevelopment/oobtainium/network/members)
[![NuGet](https://img.shields.io/github/stars/OutOfBandDevelopment/oobtainium?style=social)](https://github.com/OutOfBandDevelopment/oobtainium/stargazers)