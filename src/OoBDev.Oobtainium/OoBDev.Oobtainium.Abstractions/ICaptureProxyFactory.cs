﻿using Microsoft.Extensions.Logging;
using OoBDev.Oobtainium.Recording;

namespace OoBDev.Oobtainium
{
    /// <summary>
    /// Capture Proxy Factory is used to generate a proxy class for a given interface
    /// </summary>
    public interface ICaptureProxyFactory
    {
        /// <summary>
        /// This method allows for creating a dynamic proxy class for the provided interface
        /// </summary>
        /// <typeparam name="T">Interface to Implement</typeparam>
        /// <param name="handler">Optional: may be passed in or provided though the IServiceProvider</param>
        /// <param name="Recorder">Optional: may be passed in or provided though the IServiceProvider</param>
        /// <param name="logger">Optional: may be passed in or provided though the IServiceProvider</param>
        /// <returns></returns>
        T Create<T>(
            ICallHandler? handler = null,
            ILogger<T>? logger = null
            );

        T CreateWithRecorder<T>(
            ICallRecorder? recorder = null,
            ICallHandler? handler = null,
            ILogger<T>? logger = null
            );
    }
}