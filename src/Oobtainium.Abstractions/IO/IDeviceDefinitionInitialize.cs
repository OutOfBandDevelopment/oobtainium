﻿using System.Threading;
using System.Threading.Tasks;

namespace OoBDev.Oobtainium.IO;

public interface IDeviceDefinitionInitialize
{
    Task InitializeAsync(IDeviceAdapter device, CancellationToken token);
}