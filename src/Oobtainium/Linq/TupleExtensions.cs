using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using OoBDev.Oobtainium.Linq;

namespace OoBDev.Oobtainium.Linq;

public static class TupleExtensions
{
    public static object?[] ToArray(this ITuple tuple) =>
        Enumerable.Range(0, tuple.Length).Select(i => tuple[i]).ToArray();
    public static T?[] ToArray<T>(this ITuple tuple) =>
        Enumerable.Range(0, tuple.Length).Select(i => (T?)tuple[i]).ToArray();
    public static IReadOnlyList<T?> ToList<T>(this ITuple tuple) =>
        Enumerable.Range(0, tuple.Length).Select(i => (T?)tuple[i]).ToArray();
}
