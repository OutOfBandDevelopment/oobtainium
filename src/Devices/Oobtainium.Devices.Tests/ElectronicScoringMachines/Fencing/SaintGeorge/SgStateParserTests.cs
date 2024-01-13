﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OoBDev.Oobtainium.Devices.Tests.ElectronicScoringMachines.Fencing.SaintGeorge;

[TestClass]
public class SgStateParserTests
{
}
/*
0x01,0x12,0x50,0x3f,0x00,0x02,0x00,0x41,0x41,0x38,0x47,0x04
0x01,0x13,0x43,0x30,0x30,0x24,0x02,0x04
0x01,0x13,0x43,0x30,0x30,0x30,0x30,0x04
0x01,0x13,0x43,0x30,0x30,0x3a,0x30,0x04
0x01,0x13,0x43,0x30,0x31,0x30,0x30,0x04
0x01,0x13,0x43,0x30,0x31,0x3a,0x31,0x04
0x01,0x13,0x43,0x30,0x32,0x30,0x31,0x04
0x01,0x13,0x43,0x30,0x32,0x3a,0x31,0x04
0x01,0x13,0x43,0x30,0x33,0x30,0x31,0x04
0x01,0x13,0x43,0x31,0x31,0x3a,0x31,0x04
0x01,0x13,0x43,0x31,0x32,0x3a,0x31,0x04
0x01,0x13,0x43,0x31,0x33,0x3a,0x31,0x04
0x01,0x13,0x43,0x32,0x30,0x31,0x02,0x04
0x01,0x13,0x43,0x32,0x30,0x31,0x32,0x04
0x01,0x13,0x43,0x33,0x33,0x31,0x31,0x04
0x01,0x13,0x4c,0x52,0x30,0x47,0x30,0x57,0x30,0x77,0x30,0x04
0x01,0x13,0x4c,0x52,0x30,0x47,0x30,0x57,0x30,0x77,0x31,0x04
0x01,0x13,0x4c,0x52,0x30,0x47,0x30,0x57,0x31,0x77,0x30,0x04
0x01,0x13,0x4c,0x52,0x30,0x47,0x30,0x57,0x31,0x77,0x31,0x04
0x01,0x13,0x4c,0x52,0x30,0x47,0x31,0x57,0x30,0x77,0x30,0x04
0x01,0x13,0x4c,0x52,0x30,0x47,0x31,0x57,0x31,0x77,0x30,0x04
0x01,0x13,0x4c,0x52,0x30,0x47,0x31,0x57,0x31,0x77,0x31,0x04
0x01,0x13,0x4c,0x52,0x31,0x47,0x30,0x57,0x30,0x77,0x30,0x04
0x01,0x13,0x4c,0x52,0x31,0x47,0x30,0x57,0x31,0x77,0x30,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x30,0x30,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x30,0x31,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x30,0x32,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x30,0x33,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x30,0x34,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x30,0x35,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x30,0x36,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x30,0x37,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x30,0x38,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x30,0x39,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x31,0x30,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x31,0x31,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x31,0x32,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x31,0x33,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x31,0x34,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x31,0x35,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x31,0x36,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x31,0x37,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x31,0x38,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x31,0x39,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x32,0x30,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x32,0x31,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x32,0x32,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x32,0x33,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x32,0x34,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x32,0x35,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x32,0x36,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x32,0x37,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x32,0x38,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x32,0x39,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x33,0x30,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x33,0x31,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x33,0x32,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x33,0x33,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x33,0x34,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x33,0x35,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x33,0x36,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x33,0x37,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x33,0x38,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x33,0x39,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x34,0x30,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x34,0x31,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x34,0x32,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x34,0x33,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x34,0x34,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x34,0x35,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x34,0x36,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x34,0x37,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x34,0x38,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x34,0x39,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x35,0x30,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x35,0x31,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x35,0x32,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x35,0x33,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x35,0x34,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x35,0x35,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x35,0x36,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x35,0x37,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x35,0x38,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x30,0x3a,0x35,0x39,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x31,0x3a,0x30,0x30,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x32,0x3a,0x30,0x30,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x52,0x5f,0x46,0x24,0x02,0x10,0x30,0x30,0x30,0x30,0x5f,0x5f,0x3a,0x30,0x33,0x3a,0x30,0x30,0x2e,0x5f,0x5f,0x5f,0x04
0x01,0x13,0x53,0x30,0x30,0x3a,0x30,0x30,0x04
0x01,0x13,0x53,0x30,0x31,0x3a,0x30,0x30,0x04
0x01,0x13,0x53,0x30,0x32,0x3a,0x30,0x30,0x04
0x01,0x13,0x53,0x30,0x33,0x3a,0x30,0x30,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x30,0x30,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x30,0x31,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x30,0x32,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x30,0x33,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x30,0x34,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x30,0x35,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x30,0x36,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x30,0x37,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x30,0x38,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x30,0x39,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x31,0x30,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x31,0x31,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x31,0x32,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x31,0x33,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x31,0x34,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x31,0x35,0x04
0x01,0x13,0x53,0x30,0x34,0x3a,0x31,0x36,0x04
0x01,0x13,0x53,0x30,0x35,0x3a,0x31,0x36,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x30,0x3a,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x31,0x3a,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x32,0x3a,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x33,0x3a,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x30,0x31,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x30,0x32,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x30,0x33,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x30,0x34,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x30,0x35,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x30,0x36,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x30,0x37,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x30,0x38,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x30,0x39,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x31,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x31,0x31,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x31,0x32,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x31,0x33,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x31,0x34,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x31,0x35,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x34,0x3a,0x30,0x31,0x36,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x35,0x3a,0x30,0x31,0x36,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x35,0x3a,0x30,0x31,0x36,0x02,0x30,0x30,0x30,0x30,0x02,0x30,0x32,0x30,0x31,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x35,0x3a,0x30,0x31,0x36,0x02,0x30,0x31,0x30,0x30,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x35,0x3a,0x30,0x31,0x36,0x02,0x30,0x31,0x30,0x30,0x02,0x30,0x31,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x35,0x3a,0x30,0x31,0x36,0x02,0x30,0x32,0x30,0x31,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x35,0x3a,0x30,0x31,0x36,0x02,0x30,0x32,0x30,0x31,0x02,0x30,0x31,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x35,0x3a,0x30,0x31,0x36,0x02,0x30,0x33,0x30,0x31,0x02,0x30,0x30,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x35,0x3a,0x30,0x31,0x36,0x02,0x30,0x33,0x30,0x31,0x02,0x30,0x31,0x30,0x30,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x53,0x54,0x02,0x30,0x30,0x35,0x3a,0x30,0x31,0x36,0x02,0x30,0x33,0x30,0x31,0x02,0x30,0x33,0x30,0x31,0x02,0x33,0x02,0x30,0x30,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x30,0x30,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x30,0x31,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x30,0x32,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x30,0x33,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x30,0x34,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x30,0x35,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x30,0x36,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x30,0x37,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x30,0x38,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x30,0x39,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x31,0x30,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x31,0x31,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x31,0x32,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x31,0x33,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x31,0x34,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x31,0x35,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x31,0x36,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x31,0x37,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x31,0x38,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x31,0x39,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x32,0x30,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x32,0x31,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x32,0x32,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x32,0x33,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x32,0x34,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x32,0x35,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x32,0x36,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x32,0x37,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x32,0x38,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x32,0x39,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x33,0x30,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x33,0x31,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x33,0x32,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x33,0x33,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x33,0x34,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x33,0x35,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x33,0x36,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x33,0x37,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x33,0x38,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x33,0x39,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x34,0x30,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x34,0x31,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x34,0x32,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x34,0x33,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x34,0x34,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x34,0x35,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x34,0x36,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x34,0x37,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x34,0x38,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x34,0x39,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x35,0x30,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x35,0x31,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x35,0x32,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x35,0x33,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x35,0x34,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x35,0x35,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x35,0x36,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x35,0x37,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x35,0x38,0x04
0x01,0x13,0x54,0x30,0x30,0x3a,0x35,0x39,0x04
0x01,0x13,0x54,0x30,0x31,0x3a,0x30,0x30,0x04
0x01,0x13,0x54,0x30,0x32,0x3a,0x30,0x30,0x04
0x01,0x13,0x54,0x30,0x33,0x3a,0x30,0x30,0x04
*/