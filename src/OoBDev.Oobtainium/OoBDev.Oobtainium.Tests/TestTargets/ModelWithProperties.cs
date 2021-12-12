using System;
using System.Collections.Generic;
using System.Text;

namespace OoBDev.Oobtainium.Tests.TestTargets
{
    public class ModelWithProperties
    {
        public string String { get; set; }

        public int Integer { get; set; }
        public int? IntegerNull { get; set; }

        public uint UInteger { get; set; }
        public uint? UIntegerNull { get; set; }

        public long Long { get; set; }
        public long? LongNull { get; set; }

        public ulong ULong { get; set; }
        public ulong? ULongNull { get; set; }

        public DateTime DateTime { get; set; }
        public DateTimeOffset DateTimeOffset { get; set; }
        public TimeSpan TimeSpan { get; set; }

        public Guid Guid { get; set; }
    }

    public class ModelWithProperties2
    {
        public string String { get; set; }
        public int Integer { get; set; }
    }

    public class ModelWithProperties3 : ModelWithProperties
    {
    }
}
