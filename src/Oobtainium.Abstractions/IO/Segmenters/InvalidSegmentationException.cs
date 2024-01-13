using System;
using System.Runtime.Serialization;

namespace OoBDev.Oobtainium.IO.Segmenters;

[Serializable]
public class InvalidSegmentationException : Exception
{
    public InvalidSegmentationException()
    {
    }
}